using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Assignment3WF
{

    public sealed class checkExpDate : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> InDate { get; set; }

        public OutArgument<Boolean> OutDate { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            DateTime date; // create a date variable
            string expDate = context.GetValue(InDate);// Obtain the runtime value of the InDate input argument

            if (DateTime.TryParse(expDate, out date)) //Convert string input to date type
            {
                if (date < DateTime.Now) { context.SetValue(OutDate, false); }//If the given date is in the past return false
                else { context.SetValue(OutDate, true); }//The card must valid until the future date.
            }
            else
            {
                context.SetValue(OutDate, false);// return false if given wrong input type
            }
        }
    }
}
