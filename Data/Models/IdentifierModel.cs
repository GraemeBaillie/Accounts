using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_example_app.Data
{
    public class IdentifierModel
    {
        //Thought sortcode looked like an integer but guessing its been made a string in the json to deal with potential dashes
	    public string SortCode { get;set; }
        public string AccountNumber { get;set; }
		//Making an assumption this is a string however have made it an object to be safe
        public object SecondaryIdentification { get; set; }
    }

}
