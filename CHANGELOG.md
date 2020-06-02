# v1.1.0
Updating to utilize the newest features in [ProphetsWay.BaseDataAccess](https://github.com/ProphetManX/ProphetsWay.BaseDataAccess).
Removing the Exmaple DataAccess project and referencing the [ProphetsWay.Example](https://github.com/ProphetManX/ProphetsWay.Example) 
repo for DataAccess and Unit Tests.  Found and fixed a bunch of minor errors in the example projects meant to illustrate how easy everything
is setup and works.

Removed the dependency on [ProphetsWay.Logger](https://github.com/ProphetManX/ProphetsWay.Logger) 
as it was only used for two minor logging statements, and the Error statement now wraps the exception with a new message and throws.

Removed the dependency on [ProphetsWay.Utilities](https://github.com/ProphetManX/ProphetsWay.Utilities)
as it was only used for a single enum parse, which I've just written that method directly within the EnumTypeHandler class.

For any questions or problems with [iBatis.Net](https://ibatis.apache.org/docs/dotnet/datamapper/index.html) please see the linked
documentation.


# v1.0.0
Initial Release!
Created a few BaseDao's, two EnumTypeHandlers, and a MapperFactory to help out with using iBatis as an ORM setup in your DAL.
