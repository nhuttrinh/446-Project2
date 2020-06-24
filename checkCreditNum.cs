using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Assignment3WF
{

    public sealed class checkCreditNum : CodeActivity
    {// Define an activity input argument of type string
        public InArgument<string> CreditNumber { get; set; }
        public OutArgument<Boolean> CreditResult { get; set; }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the CreditNumber input argument
            string creditNum = context.GetValue(CreditNumber);
            int sum = 0;//sum total

                int[] arr = new int[16]; //initalize an array for digits

                bool check = false;//used to separate between digits. In this case, using 'check' to take even digits if it is true.

                for (int i = 0; i <= 15; i++)
                {
                    arr[i] = Convert.ToInt32(creditNum.Substring(i, 1)); //Covert digits to integer type

                }

                for (int i = 15; i >= 0; i--)
                {
                    if (check) //Start from the right side of card number, separate even and odd digits.
                    {
                        arr[i] = arr[i] * 2; // Double the digits
                        if (arr[i] > 9) //If the result is greater than 9
                        {
                            arr[i] = arr[i] - 9; //Then minus 9
                        }
                    }
                    sum = sum + arr[i]; //Adding digits to the sum
                    check = !check;//Switch the state of check
                }

                if (sum % 10 == 0)
                {
                    context.SetValue(CreditResult, true);//return true if the sum is divisible by 10
                }
                else
                {
                    context.SetValue(CreditResult, false);//return false if the sum is not divisible by 10
                }
            }
        }
    }


