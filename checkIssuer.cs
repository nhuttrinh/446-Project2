using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Assignment3WF
{

    public sealed class checkIssuer : CodeActivity
    {

        // Define an activity input argument of type string
        public InArgument<string> CreditNum { get; set; }

        public OutArgument<int> Issuer { get; set; }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the CreditNum input argument
            string creditNum = context.GetValue(CreditNum);

           
                if (creditNum.Substring(0, 1) == "4") // Check if the card is Visa
                {
                    context.SetValue(Issuer, 3);
                }
                else if (creditNum.Substring(0, 2) == "51" && creditNum.Substring(6, 2) == "55") // Check if the card is Mastercard
                {
                    context.SetValue(Issuer, 3);
                }
                else if (creditNum.Substring(0, 4) == "6011" || creditNum.Substring(0, 3) == "644" || creditNum.Substring(0, 2) == "65")//Check if the card is Discovery
                {
                    context.SetValue(Issuer, 3);
                }
                else if (creditNum.Substring(0, 2) == "34" || creditNum.Substring(6, 2) == "37")// Check if the card is American Express
                {
                    context.SetValue(Issuer, 4);
                }
                else
                {
                    context.SetValue(Issuer, -1);//Other card is not valid
                }
            }
        }
    }


