using IBatisNet.DataMapper.TypeHandlers;
using ProphetsWay.Utilities;

namespace ProphetsWay.iBatisTools
{
    public abstract class EnumTypeHandler<T> : ITypeHandlerCallback
    {
        public abstract void SetParameter(IParameterSetter setter, object parameter);

        public object GetResult(IResultGetter getter)
        {
            var output = getter.Value.ToString().GetValue<T>();
            return output;
        }

        public object ValueOf(string s)
        {
            return s;
        }

        public object NullValue => default(T);
    }
}
