using System;
using System.Text.RegularExpressions;

namespace BusinessObject
{
    public class MemberObject
    {
        private int _memberId;

        public int MemberID
        {
            get { return _memberId; }
            set { _memberId = value; }
        }

        private string _memberName;

        public string MemberName
        {
            get { return _memberName; }
            set 
            { 
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name is required");
                }
                else
                {
                    _memberName = value;
                }
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { 
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email is required");
                }
                else if(!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                {
                    throw new ArgumentException("Invalid email format");
                }
                else
                {
                    _email = value;
                }
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set 
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Password is required");
                }
                else
                {
                    _password = value;
                }
            }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set 
            { 
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("City is required");
                }
                else
                {
                    _city = value;
                }
            }
        }

        private string _country;

        public string Country
        {
            get { return _country; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Country is required");
                }
                else
                {
                    _country = value;
                }
            }
        }

        override
        public String ToString()
        {
            return MemberID + ";" + MemberName + ";" + Email + ";" + Password + ";" + City + ";" + Country;
        }
    }
}
