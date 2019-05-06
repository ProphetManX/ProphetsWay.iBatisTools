using IBatisNet.DataMapper.TypeHandlers;

namespace ProphetsWay.iBatisTools
{
    public abstract class EnumTypeAsStringHandler<T> : EnumTypeHandler<T>
    {
        public override void SetParameter(IParameterSetter setter, object parameter)
        {
            setter.Value = ((T)parameter).ToString();
        }
    }
}
