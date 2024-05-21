using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.RegularExpressions;
using System.Xml.Linq;


namespace AbraAssignment.Server.Models
{
	public class Pet
	{
		const int MAX_CHARACTERS = 25;
		const int MAX_AGE = 20;

		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string _id { get; set; }

		[BsonElement("name")]
		public string Name { get; set; }

		[BsonElement("created_at")]
		public string CreatedAt { get; set; }

		[BsonElement("type")]
		public string Type { get; set; }

		[BsonElement("color")]
		public string Color { get; set; }

		[BsonElement("age")]
		public int Age { get; set; }

		public bool Validate()
		{
			bool isValid = true;

			validName(this.Name, ref isValid);
			validColor(this.Color, ref isValid);
			validAge(this.Age, ref isValid);

			return isValid;
		}

		private void validName(string name, ref bool isValid)
		{
			if (name == null || name.Length > MAX_CHARACTERS) 
			{
				isValid = false;
			}
		}

		private void validColor(string color, ref bool isValid)
		{
			string strRegex = @"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$";
			Regex re = new Regex(strRegex);
			if (!re.IsMatch(color))
			{
				isValid = false;
			}
		}

		private void validAge(int age, ref bool isValid)
		{
			if (age > MAX_AGE)
			{
				isValid = false;
			}
		}
	}
}
