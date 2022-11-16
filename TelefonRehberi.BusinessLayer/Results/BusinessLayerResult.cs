using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entities.Messages;

namespace TelefonRehberi.BusinessLayer.Results
{
    public class BusinessLayerResult<T> where T:class
    {
        public T Result { get; set; }

        public List<ErrorMessageObj> Errors { get; set; }


        public BusinessLayerResult()
        {
            Errors = new List<ErrorMessageObj>();
        }

        public void ErrorAdd(ErrorMessageCode code, string message)
        {
            Errors.Add(new ErrorMessageObj()
            {
                Code = code,
                Message = message
            });
        }
    }
}
