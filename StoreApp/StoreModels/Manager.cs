using System;
namespace StoreModels
{
    public class Manager
    {
        private string managerName;
        private string managerEmail;
        private string savedPasswordHash;
        private string managerPhoneNumber;
        private Location managerLocation;

        public string ManagerName { 
            get {return managerName;}
            set {
                if (value == null || value.Equals("")) {
                    throw new ArgumentNullException("Manager name cannot be empty or null");
                }
                managerName = value;
            }
            }
        public string ManagerEmail { 
            get {return managerEmail;}
            set {
                if (value == null) {
                    //TODO: throw exception
                }
                managerEmail = value;
            } 
         }
        public string SavedPasswordHash { 
            get { return savedPasswordHash; }
            set {
                if (value.Equals(null)) {
                    //TODO: throw Exception
                }
                savedPasswordHash = value;
            }
         }
        public string ManagerPhoneNumber { 
            get {
                return managerPhoneNumber;
            } 
            set {
                if (value.Equals(null)) {
                    //TODO: throw exception
                }
                //format phone number
                managerPhoneNumber = value;
            } 
         } 
        public Location ManagerLocation { 
            get {return managerLocation;}
            set {
                if (value == null) {
                    //todo: throw exception
                }
                managerLocation = value;
            }
        }

        public override string ToString() => $"Manager Details: \n\t Name: {this.ManagerName} \n\t Email: {this.ManagerEmail} \n\t Phone: {this.ManagerPhoneNumber}";
    }
}