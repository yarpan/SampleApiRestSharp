using System.Collections.Generic;

namespace SampleApiRestSharp
{
    public class OwnerDto
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string telephone { get; set; }
        public int id { get; set; }

        public override bool Equals(object obj)
        {
            return obj is OwnerDto dto &&
                   firstName == dto.firstName &&
                   lastName == dto.lastName &&
                   address == dto.address &&
                   city == dto.city &&
                   telephone == dto.telephone;
        }

        public override int GetHashCode()
        {
            int hashCode = -1784342392;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(firstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(lastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(address);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(city);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(telephone);
            return hashCode;
        }
    }
}
