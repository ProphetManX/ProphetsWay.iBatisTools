# ProphetsWay.iBatisTools
A small library that will help with using iBatisNet as your DAL

In my testing I have found that I can't get iBatisNet to work in Net Core Test application, so I have the iBatisTools project
only building in Net Framework setups for now.  If anyone can get me a version of iBatisNet that I can use in both Net Framework
and Net Core, I will be absolutely happy to upgrade this to support them both as well.


## How to use
You can reference iBatisTools from NuGet.  Once you have it in your project, you will be able to write custom implementations
for your DAL, however some functionality will be handled for you in base abstract classes that you can inherit from.  I will
try to explain each of the base classes in order of how I would probably code a new project from scratch.

For examples, please see the example projects included in the GitHub repository.

## Base Dao Classes
##### Special note
iBatisTools references interfaces that were established in another project, ProphetsWay.BaseDataAccess.  The point of mentioning
this is that you will need to follow the guidelines for the DAO interfaces defined within that project 
(but only to make use of the BaseDao classes).


### BaseDao
This Dao implements the IBaseDao interface, meaning it has all the CRUD calls established within.  It is built around a specific
naming convention to be used within your SqlMap.xml files.  The following methods are implemented:

``` c#
T Get(T item);
void Insert(T item);
int Update(T item);
int Delete(T item);
```

To make use of these methods, you must set the namespace in your SqlMap.xml files to be the literal name of the entity it is for.
For example, if you have a POCO named ```Company``` then in your SqlMap.xml you need ```namespace="Company"```.  Then 
you will need to have four specifically named queries created.

``` xml
<select id="Get[EntityName]ById" parameterClass="[Namespace].[EntityName]" />
<insert id="Insert[EntityName]" parameterClass="[Namespace].[EntityName]" />
<update id="Update[EntityName]" parameterClass="[Namespace].[EntityName]" />
<update id="Delete[EntityName]ById" parameterClass="[Namespace].[EntityName]" />
```
When setup as per the previous example entity ```Company```
``` xml
<select id="GetCompanyById" parameterClass="ProphetsWay.iBatisTools.Ex.DataAccess.Entities.Company" />
<insert id="InsertCompany" parameterClass="ProphetsWay.iBatisTools.Ex.DataAccess.Entities.Company" />
<update id="UpdateCompany" parameterClass="ProphetsWay.iBatisTools.Ex.DataAccess.Entities.Company" />
<update id="DeleteCompanyById" parameterClass="ProphetsWay.iBatisTools.Ex.DataAccess.Entities.Company" />
```

You will still need to manually write the queries however you want, but you will get the whole entity as your parameter object.
In the case for ```Get``` and ```Delete``` you only need the Id property to be set on the object, but the variable is still
the object.

### BaseGetAllDao
This Dao inherits from BaseDao and implements the IBaseGetAllDao interface.  The following method is implemented:
``` c#
IList<T> GetAll(T item);
```

Since this inherits from BaseDao, the naming convention of the SqlMap.xml is still required for the CRUD calls.  The new
query you will need to add is:
``` xml
<select id="GetAll" />
```

Unlike the methods for BaseDao, ```GetAll``` doesn't require the entity name to be part of the query name.  It also does 
not require any parameter since the point is to return all of the entity from the database.

### BasePagedDao
This Dao inherits from BaseDao and implements the IBasePagedDao interface.  The following methods are implemented:

``` c#
int GetCount(T item);
IList<T> GetPaged(T item, int skip, int take);
```

Just like above, naming convention for the namespace is required in the SqlMap.xml.  The new queries needed are:

``` xml
<select id="GetCount" resultClass="int" />
<select id="GetPaged" parameterClass="map" />
```

With ```GetCount``` no parameters are required, and the point for this is to provide an upper limit for your UI to get quickly
when rendering a paging control.  Then the ```GetPaged``` method has a ```"map"``` as it's parameter.  The two values in the
map are ```#Offset#``` and ```#PageSize#``` and you should use them in your queries.  For the ```Company``` example 
from above:

``` xml
<select id="GetPaged" parameterClass="map" resultMap="CompanyMap">
	SELECT *
	FROM dbo.Companies
	OFFSET #Offset#
	ROWS FETCH NEXT #PageSize# ROWS ONLY
</select>
```

## EnumTypeHandlers
Sometimes in your entities you use objects to reference a value from a drop down, maybe it's a string literal, and other times
you want to use an ```enum``` object value.  In order to use these with iBatis you have to use a ```TypeHandler``` class that 
implements ```ITypeHandlerCallback```.  In iBatisTools there are two options that have been setup for you to choose from:
```EnumTypeAsIntHandler<T>``` and ```EnumTypeAsStringHandler<T>```.  You will need to create a new class type handler
to work with your specific class objects, however you only need to inherit one of those two classes, and specify your class
as the generic value for T.  For example, I have the following enum and type handler created:

``` c#
//roles as an enum is defined within my DataAccess project along with all my entity models
public enum Roles
{
    Admin,
    User,
    Developer
}

//RoleHandler is defined within my iBatis DAL project 
public class RoleHandler : EnumTypeAsIntHandler<Roles>    {    } 
```

The difference between ```AsInt``` and ```AsString``` refer to how the value is stored in the database.  ```AsInt``` will store
the integer value of the enum in your database, so you would likely need to create a reference table for those values to map to
for database sanity checks and queries.  Since integers are likely a smaller footprint than strings, usually this is the 
preferred implementation.  However sometimes you just want the string value of the enum stored in the database, so basic queries
can quickly inform what the value represents, for that you just use the ```AsString``` version.

