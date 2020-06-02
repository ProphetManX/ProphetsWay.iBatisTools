using IBatisNet.DataMapper.TypeHandlers;
using System;
using System.Linq;

namespace ProphetsWay.iBatisTools
{
	public abstract class EnumTypeHandler<T> : ITypeHandlerCallback
	{
		public abstract void SetParameter(IParameterSetter setter, object parameter);

		public object GetResult(IResultGetter getter)
		{
			EnumTryParse(getter.Value.ToString(), out T output);
			return output;
		}

		public object ValueOf(string s)
		{
			return s;
		}

		public object NullValue => default(T);

		private void EnumTryParse(string strEnumValue, out T result)
		{
			if (string.IsNullOrEmpty(strEnumValue))
			{
				result = default;
				return;
			}

			var typeFixed = strEnumValue.Replace(' ', '_');
			if (Enum.IsDefined(typeof(T), typeFixed))
				result = (T)Enum.Parse(typeof(T), typeFixed, true);
			else
			{
				result = default;

				foreach (var value in Enum.GetNames(typeof(T)).Where(value => value.Equals(typeFixed, StringComparison.OrdinalIgnoreCase)))
				{
					result = (T)Enum.Parse(typeof(T), value);
					return;
				}

				result = (T)Enum.Parse(typeof(T), strEnumValue);
			}
		}
	}
}
