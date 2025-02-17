using Microsoft.AspNetCore.Mvc;

namespace APIASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase{
      

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger){
            _logger = logger;
        }

        [HttpGet(Name = "sum/{firstNumber}/{secoundNumber}")]
        public IActionResult Sum(string firstNumber, string secoundNumber) {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber)) {
                var sum = ConnvertToDecimal(firstNumber) + ConnvertToDecimal(secoundNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet(Name ="sub/{firstNumber}/{secoundNumber}")]
        public IActionResult Sub(string firstNumber, string secoundNumber) {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber)) {
                var sub = ConnvertToDecimal(firstNumber) / ConnvertToDecimal(secoundNumber);
                return Ok(sub.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet(Name = "mult/{firstNumber}/{secoundNumber}")]
        public IActionResult Mult(string firstNumber, string secoundNumber) {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber))
            {
                var mult = ConnvertToDecimal(firstNumber) * ConnvertToDecimal(secoundNumber);
                return Ok(mult.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet(Name = "med/{firstNumber}/{secoundNumber}")]
        public IActionResult Med(string firstNumber, string secoundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secoundNumber))
            {
                var med = (ConnvertToDecimal(firstNumber) + ConnvertToDecimal(secoundNumber)) / 2;
                return Ok(med.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet(Name = "root/{firstNumber}/{secoundNumber}")]
        public IActionResult Root(string firstNumber) {
            if (IsNumeric(firstNumber)){
                var med = (Math.Sqrt((double)ConnvertToDecimal(firstNumber)));
                return Ok(med.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private decimal ConnvertToDecimal(string strNumber){
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue)) {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string strNumber){
            double number;

            bool isNumber = double.TryParse(
                strNumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);

            return isNumber;
        }
    }
}
