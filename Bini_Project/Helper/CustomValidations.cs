using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Bini_Project.Helper
{
    public class CustomValidations
    {
        [AttributeUsage(AttributeTargets.Class,AllowMultiple=true)]
        public class AtLeastOneProperty:ValidationAttribute
        {
            private string[] propList { get; set; }
            public AtLeastOneProperty(params string[] _propList)
            {
                this.propList = _propList;
            }

            public override object TypeId
            {
                get
                {
                    return this;
                }
            }

            public override bool IsValid(object value)
            {
                PropertyInfo propertyInfo;
                foreach(string propName in propList)
                {
                    propertyInfo = value.GetType().GetProperty(propName);

                    if(propertyInfo != null && propertyInfo.GetValue(value,null) != null)
                    {
                        return true;
                    }

                }

                return false;
            }

        }
    }
}