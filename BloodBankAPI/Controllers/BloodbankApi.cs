using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BloodBankAPI.Models;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodbankApi : ControllerBase
    {
        static List<BloodBank> bloodBanks = new List<BloodBank>
        {
            new BloodBank { Id = 1, DonorName = "Ajay Sharma", Age = 45, BloodType = "O-", ContactInfo = "123456789", Quantity = 300, CollectionDate = new DateOnly(2024, 11, 1), ExpirationDate = new DateOnly(2024, 12, 1), Status = "Available" },
            new BloodBank { Id = 2, DonorName = "Raj Verma", Age = 30, BloodType = "A+", ContactInfo = "987654321", Quantity = 260, CollectionDate = new DateOnly(2024, 11, 2), ExpirationDate = new DateOnly(2024, 12, 4), Status = "Requested" },
            new BloodBank { Id = 3, DonorName = "Pooja Mehta", Age = 35, BloodType = "B-", ContactInfo = "456789123", Quantity = 320, CollectionDate = new DateOnly(2024, 10, 30), ExpirationDate = new DateOnly(2024, 11, 30), Status = "Available" },
            new BloodBank { Id = 4, DonorName = "Ravi Gupta", Age = 40, BloodType = "AB+", ContactInfo = "159753486", Quantity = 470, CollectionDate = new DateOnly(2024, 10, 25), ExpirationDate = new DateOnly(2024, 12, 11), Status = "Available" },
            new BloodBank { Id = 5, DonorName = "Sonal Kapoor", Age = 29, BloodType = "O+", ContactInfo = "753159852", Quantity = 340, CollectionDate = new DateOnly(2024, 10, 28), ExpirationDate = new DateOnly(2024, 12, 8), Status = "Requested" },
            new BloodBank { Id = 6, DonorName = "Manish Kumar", Age = 34, BloodType = "A-", ContactInfo = "102938475", Quantity = 410, CollectionDate = new DateOnly(2024, 10, 29), ExpirationDate = new DateOnly(2024, 12, 10), Status = "Available" },
            new BloodBank { Id = 7, DonorName = "Anjali Roy", Age = 28, BloodType = "B+", ContactInfo = "564738291", Quantity = 290, CollectionDate = new DateOnly(2024, 10, 30), ExpirationDate = new DateOnly(2024, 12, 7), Status = "Available" },
            new BloodBank { Id = 8, DonorName = "Vivek Joshi", Age = 48, BloodType = "AB-", ContactInfo = "947382615", Quantity = 260, CollectionDate = new DateOnly(2024, 9, 27), ExpirationDate = new DateOnly(2024, 11, 1), Status = "Expired" },
            new BloodBank { Id = 9, DonorName = "Nisha Patel", Age = 31, BloodType = "O-", ContactInfo = "738291564", Quantity = 380, CollectionDate = new DateOnly(2024, 10, 30), ExpirationDate = new DateOnly(2024, 12, 6), Status = "Requested" },
            new BloodBank { Id = 10, DonorName = "Amit Singh", Age = 42, BloodType = "A+", ContactInfo = "111213141", Quantity = 270, CollectionDate = new DateOnly(2024, 11, 1), ExpirationDate = new DateOnly(2024, 12, 2), Status = "Available" },
            new BloodBank { Id = 11, DonorName = "Deepa Nair", Age = 55, BloodType = "B-", ContactInfo = "888999777", Quantity = 330, CollectionDate = new DateOnly(2024, 9, 26), ExpirationDate = new DateOnly(2024, 11, 4), Status = "Expired" },
            new BloodBank { Id = 12, DonorName = "Kunal Saxena", Age = 60, BloodType = "O+", ContactInfo = "555666444", Quantity = 400, CollectionDate = new DateOnly(2024, 10, 29), ExpirationDate = new DateOnly(2024, 12, 7), Status = "Requested" },
            new BloodBank { Id = 13, DonorName = "Ramesh Yadav", Age = 22, BloodType = "A-", ContactInfo = "777888666", Quantity = 250, CollectionDate = new DateOnly(2024, 11, 3), ExpirationDate = new DateOnly(2024, 12, 10), Status = "Available" },
            new BloodBank { Id = 14, DonorName = "Seema Desai", Age = 33, BloodType = "AB+", ContactInfo = "333444555", Quantity = 450, CollectionDate = new DateOnly(2024, 11, 4), ExpirationDate = new DateOnly(2024, 12, 12), Status = "Available" },
            new BloodBank { Id = 15, DonorName = "Aakash Rana", Age = 29, BloodType = "O-", ContactInfo = "222333111", Quantity = 270, CollectionDate = new DateOnly(2024, 9, 24), ExpirationDate = new DateOnly(2024, 11, 1), Status = "Expired" },
            new BloodBank { Id = 16, DonorName = "Jyoti Singh", Age = 36, BloodType = "B+", ContactInfo = "111555222", Quantity = 460, CollectionDate = new DateOnly(2024, 11, 2), ExpirationDate = new DateOnly(2024, 12, 5), Status = "Available" },
            new BloodBank { Id = 17, DonorName = "Rahul Khanna", Age = 24, BloodType = "A+", ContactInfo = "666111555", Quantity = 410, CollectionDate = new DateOnly(2024, 10, 30), ExpirationDate = new DateOnly(2024, 12, 9), Status = "Requested" },
            new BloodBank { Id = 18, DonorName = "Ritu Gupta", Age = 47, BloodType = "AB-", ContactInfo = "555222111", Quantity = 350, CollectionDate = new DateOnly(2024, 9, 25), ExpirationDate = new DateOnly(2024, 11, 3), Status = "Expired" },
            new BloodBank { Id = 19, DonorName = "Vinod Mehta", Age = 52, BloodType = "B-", ContactInfo = "888444555", Quantity = 380, CollectionDate = new DateOnly(2024, 11, 1), ExpirationDate = new DateOnly(2024, 12, 6), Status = "Available" },
            new BloodBank { Id = 20, DonorName = "Sanjay Sharma", Age = 39, BloodType = "O+", ContactInfo = "333777444", Quantity = 450, CollectionDate = new DateOnly(2024, 11, 5), ExpirationDate = new DateOnly(2024, 12, 10), Status = "Requested" },
            new BloodBank { Id = 21, DonorName = "Parul Verma", Age = 43, BloodType = "A-", ContactInfo = "444555666", Quantity = 290, CollectionDate = new DateOnly(2024, 11, 6), ExpirationDate = new DateOnly(2024, 12, 13), Status = "Available" },
            new BloodBank { Id = 22, DonorName = "Naveen Jha", Age = 57, BloodType = "AB+", ContactInfo = "333111444", Quantity = 270, CollectionDate = new DateOnly(2024, 9, 30), ExpirationDate = new DateOnly(2024, 11, 4), Status = "Expired" },
            new BloodBank { Id = 23, DonorName = "Roshni Dubey", Age = 26, BloodType = "B-", ContactInfo = "555333666", Quantity = 330, CollectionDate = new DateOnly(2024, 11, 4), ExpirationDate = new DateOnly(2024, 12, 8), Status = "Requested" },
            new BloodBank { Id = 24, DonorName = "Vikas Kapoor", Age = 50, BloodType = "O-", ContactInfo = "444222555", Quantity = 420, CollectionDate = new DateOnly(2024, 11, 3), ExpirationDate = new DateOnly(2024, 12, 7), Status = "Available" },
            new BloodBank { Id = 25, DonorName = "Kiran Malhotra", Age = 29, BloodType = "A+", ContactInfo = "666999111", Quantity = 370, CollectionDate = new DateOnly(2024, 9, 26), ExpirationDate = new DateOnly(2024, 11, 5), Status = "Expired" },
            new BloodBank { Id = 26, DonorName = "Sumit Jain", Age = 41, BloodType = "B+", ContactInfo = "777111888", Quantity = 250, CollectionDate = new DateOnly(2024, 11, 1), ExpirationDate = new DateOnly(2024, 12, 1), Status = "Available" },
            new BloodBank { Id = 27, DonorName = "Megha Deshmukh", Age = 34, BloodType = "AB-", ContactInfo = "888222444", Quantity = 400, CollectionDate = new DateOnly(2024, 10, 27), ExpirationDate = new DateOnly(2024, 12, 10), Status = "Requested" },
            new BloodBank { Id = 28, DonorName = "Pradeep Rai", Age = 62, BloodType = "O+", ContactInfo = "111222333", Quantity = 460, CollectionDate = new DateOnly(2024, 11, 2), ExpirationDate = new DateOnly(2024, 12, 9), Status = "Available" },
            new BloodBank { Id = 29, DonorName = "Neha Tiwari", Age = 49, BloodType = "A-", ContactInfo = "555888999", Quantity = 390, CollectionDate = new DateOnly(2024, 9, 29), ExpirationDate = new DateOnly(2024, 11, 5), Status = "Expired" },
            new BloodBank { Id = 30, DonorName = "Raghav Sharma", Age = 28, BloodType = "B-", ContactInfo = "999555333", Quantity = 280, CollectionDate = new DateOnly(2024, 10, 30), ExpirationDate = new DateOnly(2024, 12, 6), Status = "Requested" }

        };

        string[] bloodTypes = { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };
        string[] statusList = { "available", "requested", "expired" };

        //1 Read -->  Retrieve all entries in the blood bank list.
        [HttpGet]
        public ActionResult<IEnumerable<BloodBank>> GetAll()
        {
            if (bloodBanks == null|| bloodBanks.Count == 0)
            {
                return NoContent();
            }
            return bloodBanks;
        }

        // 2 Get by ID
        [ HttpGet ("{id}") ]
        public ActionResult<BloodBank> GetById(int id)
        {
            if(id <= 0)
            {
                return BadRequest("Invalid Id");
            }
            var blood = bloodBanks.Find(i => i.Id == id);
            if (blood == null)
            {
                return NotFound("No entry with this id is available");
            }
            return Ok(blood);
        }

        //3 Add a new entry to the blood bank list.
        [HttpPost]
        public ActionResult<BloodBank> Add(BloodBank blood)
        {
            if(blood == null)
            {
                return BadRequest("Provide valid data");
            }

            //id 
            var maxId = bloodBanks.Count > 0 ? bloodBanks.Max(i => i.Id) : 0;   
            blood.Id = maxId + 1;

            //name
            if(string.IsNullOrWhiteSpace(blood.DonorName))
            {
                return BadRequest("Give a valid donor name");
            }
            
            //age
            if(blood.Age < 18 || blood.Age > 65)
            {
                return BadRequest("Age should be between 18 to 65 years.");
            }
            
            //Blood Type
            
            if(!bloodTypes.Contains(blood.BloodType.ToUpper()))
            {
                return BadRequest("Invalid blood type. Accepted values are: A+, A-, B+, B-, AB+, AB-, O+, O-.");
            }

            //contact Info
            if (!Regex.IsMatch(blood.ContactInfo, @"^[1-9]\d{9}$"))
            {
                return BadRequest("Invalid contact number");
            }
            //quantity
            if(blood.Quantity > 250 && blood.Quantity < 470)
            {
                return BadRequest("Quantity should be greater than 250 and less than 470.");
            }
            //Collection date
            if (blood.CollectionDate > DateOnly.FromDateTime(DateTime.Now))
            {
                return BadRequest("Collection date cannot be in the future.");
            }
            //expiration date
            if (blood.CollectionDate > blood.ExpirationDate)
            {
                return BadRequest("Expiration date should be after the collection date.");
            }
            //status
            if (!statusList.Contains(blood.Status.ToLower())){
                return BadRequest("Invalid status. Accepted values are available, requested, expired");
            }

            ////Expiration Date Range Validation
            //int daysBetween = (blood.ExpirationDate.ToDateTime(new TimeOnly()) - blood.CollectionDate.ToDateTime(new TimeOnly())).Days;
            //if (daysBetween < 30 || daysBetween > 47)
            //{
            //    return BadRequest("Expiration date must be between 30 and 47 days after the collection date.");
            //}

            bloodBanks.Add(blood);

            return CreatedAtAction(nameof(GetById),new {id = blood.Id }, blood);
        }

        //4 Update
        [HttpPut("{id}")]
        public ActionResult<BloodBank> UpdateById(int id, string? donorName, int? age, string? contact, string? bloodType, string? status)
        {

            if (id <= 0)
            {
                return BadRequest("Invalid id");
            }

            var entry = bloodBanks.Find(i => i.Id == id);
            if (entry == null)
            {
                return NotFound("Blood bank entry not found.");
            }

            // Donor Name 
            if (!string.IsNullOrWhiteSpace(donorName))
            {
                entry.DonorName = donorName;
            }

            // Age 
            if (age.HasValue)
            {
                if (age < 18 || age > 65)
                {
                    return BadRequest("Age should be between 18 and 65.");
                }
                entry.Age = age.Value;
            }

            // Contact Info 
            if (!string.IsNullOrWhiteSpace(contact))
            {
                if (!Regex.IsMatch(contact, @"^[1-9]\d{9}$"))
                {
                    return BadRequest("Not a valid number. It should be a 10-digit number starting with a digit from 1 to 9.");
                }
                entry.ContactInfo = contact;
            }

            // Blood Type 
            if (!string.IsNullOrWhiteSpace(bloodType))
            {
                string[] validBloodTypes = { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };
                if (!validBloodTypes.Contains(bloodType))
                {
                    return BadRequest("Invalid blood type. Accepted values are: A+, A-, B+, B-, AB+, AB-, O+, O-.");
                }
                entry.BloodType = bloodType;
            }

            // Status Validation
            if (!string.IsNullOrWhiteSpace(status))
            {
                if (!statusList.Contains(status.ToLower()))
                {
                    return BadRequest("Invalid status. Accepted values are: Available, Requested, Expired.");
                }
                entry.Status = status;
            }

            return Ok(entry);

        }

        //5 Delete based on its id
        [HttpDelete("id/{id}")]
        public IActionResult DeleteById(int id)
        {
            var entry = bloodBanks.Find(i => i.Id == id);
            if(entry == null)
            {
                return NotFound("No entry With this id ia available.");
            }
            bloodBanks.Remove(entry);
            return NoContent();
        }

        //6 Pagination
        [HttpGet("paginate/{page}/{size}")]
        public ActionResult<IEnumerable<BloodBank>> Pagination(int page, int size) 
        { 
            var result = bloodBanks.Skip((page - 1)*size).Take(size);
            return Ok(result);
        }

        //7 Search by BloodType
        [HttpGet("bloodtype/{bloodType}")]
        public ActionResult<IEnumerable<BloodBank>> SearchByBloodType (string bloodType)
        {
            if (!bloodTypes.Contains(bloodType.ToUpper()))
            {
                return BadRequest("Invalid blood type. Accepted values are: A+, A-, B+, B-, AB+, AB-, O+, O-.");
            }
            var result = bloodBanks.FindAll(i => i.BloodType.ToUpper() == bloodType.ToUpper());
            return Ok(result);
        }

        //8 Search By status
        [HttpGet("status/{status}")]
        public ActionResult<IEnumerable<BloodBank>> SearchByStatus(string status)
        {

            if (!statusList.Contains(status.ToLower()))
            {
                return BadRequest("Invalid Status. Accepted values are: available, requested, expired.");
            }
            var result = bloodBanks.FindAll(i => i.Status.ToLower() == status.ToLower());
            return Ok(result);
        }


        //9 Search By Name
        [HttpGet("donorName/{donorName}")]
        public ActionResult<IEnumerable<BloodBank>> SearchByName(string donorName)
        {
            if (string.IsNullOrWhiteSpace(donorName))
            {
                return BadRequest("Invalid Name.");
            }
            var result = bloodBanks.FindAll(i => i.DonorName.ToLower().Contains(donorName.ToLower()));
            return Ok(result);
        }

        //10 sorting by bloodType
        [HttpGet("sortByBloodType")]
        public ActionResult<IEnumerable<BloodBank>> sotyByBloodType()
        {
            if(bloodBanks.Count == 0)
            {
                return NoContent();
            }   
            var sortedList = bloodBanks.OrderBy(b => b.BloodType).ToList();
            return Ok(sortedList);
        }

        //11 sorting by bloodType
        [HttpGet("sortByCollectionDate")]
        public ActionResult<IEnumerable<BloodBank>> sortByCollectionDate()
        {
            if (bloodBanks.Count == 0)
            {
                return NoContent();
            }
            var sortedList = bloodBanks.OrderBy(b => b.CollectionDate).ToList();
            return Ok(sortedList);
        }

        //12 filtering wid Bloodtype and status
        [HttpGet("filter")]
        public ActionResult<IEnumerable<BloodBank>> SearchByStatusAndBloodType(string? status, string? bloodType)
        {
            var result = bloodBanks.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(status))
            {
                if (!statusList.Contains(status.ToLower()))
                {
                    return BadRequest("Invalid status. Accepted values are: available, requested, expired.");
                }
                result = result.Where(i => i.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(bloodType))
            {
                if (!bloodTypes.Contains(bloodType.ToUpper()))
                {
                    return BadRequest("Invalid blood type. Accepted values are: A+, A-, B+, B-, AB+, AB-, O+, O-.");
                }
                result = result.Where(i => i.BloodType.Equals(bloodType, StringComparison.OrdinalIgnoreCase));
            }

            if (!result.Any())
            {
                return NoContent();
            }

            return Ok(result);
        }

    }
}
