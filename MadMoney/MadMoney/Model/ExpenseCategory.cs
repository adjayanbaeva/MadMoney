using System;

namespace MadMoney.Model
{
    // TODO: Remember when serializing this property to file
    // Serialize as the string representation of the enum
    // Not the value. String is sturdier. More likely to withstand
    // changes to the enum between between builds of the app
    public struct ExpenseCategory
    {
        public enum Enum
        {
            Groceries,
            Restaurants,
            Rent,
            Healthcare,
            Gifts,
            TreatYoSelf
        }

        // One emojiArray to rule them all
        // This is the array of emojis that the
        // Emoji property uses to look up the emoji for this ExpenseCategory
        private static string[] emojiArray = null;

        private static void SetupEmojiArray()
        {
            emojiArray =
            new string[System.Enum.GetNames(typeof(Enum)).Length];

            // These are set here in a setup method instead of done
            // using an init list at declaration to make changing
            // emoji easier to do and less error-prone
            // Note how the name of each catetory is visually right next
            // to its emoji in the set of assignment statements below:
            emojiArray[(int)Enum.Groceries]   = "🍎";
            emojiArray[(int)Enum.Restaurants] = "🍝";
            emojiArray[(int)Enum.Rent]        = "🏠";
            emojiArray[(int)Enum.Healthcare]  = "💉";
            emojiArray[(int)Enum.Gifts]       = "🎁";
            emojiArray[(int)Enum.TreatYoSelf] = "🍧";
        }



        public ExpenseCategory(ExpenseCategory.Enum catId)
        {
            Id = catId;
        }

        // Allow implicit type conversion from the enum type to the class type
        // No data can be lost, so this is permissible
        // https://stackoverflow.com/questions/261663/can-we-define-implicit-conversions-of-enums-in-c/261696#261696
        public static implicit operator ExpenseCategory(ExpenseCategory.Enum input)
        {
            return new ExpenseCategory(input);
        }



        public Enum Id { get; set; }

        public string Emoji
        {
            get
            {
                if (emojiArray == null)
                {
                    SetupEmojiArray();
                }

                return emojiArray[(int)Id];
            }
        }

        public string Name
        {
            get
            {
                return ToString();
            }
        }

        public override string ToString()
        {
            // QUESTION: Is there a performance hit to using ToString on an enum value?
            // My intuition says that there would be some sort of reflection involved
            return Id.ToString();
        }


        public override bool Equals(object obj)
        {
            var toCompare = (ExpenseCategory)obj;

            return (Id == toCompare.Id);

        }

        public override int GetHashCode()
        {
            // TODO: Figure out what need to do about this
            throw new NotImplementedException();
        }

        public static bool operator ==(ExpenseCategory left, ExpenseCategory right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ExpenseCategory left, ExpenseCategory right)
        {
            return !(left == right);
        }
    }
}
