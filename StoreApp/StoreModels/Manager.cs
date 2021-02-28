using System;
namespace StoreModels
{
    public class Manager
    {
        private string managerName;
        private string managerEmail;
        private string savedPasswordHash;
        private string managerPhoneNumber;
        private int managerLocId;
        
        public int? Id { get; set; }

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
        public string ManagerPasswordHash { 
            get { return savedPasswordHash; }
            set {
                if (value.Equals(null)) {
                    //TODO: throw Exception
                }
                savedPasswordHash = value;
            }
         }
        public string ManagerPhone { 
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
        public int ManagerLocId { 
            get {return managerLocId;}
            set {
                if (value == null) {
                    //todo: throw exception
                }
                managerLocId = value;
            }
        }

        public override string ToString() => $"\n\t Name:\t{this.ManagerName}\n\tEmail:\t{this.ManagerEmail}\n\tPhone:\t{this.ManagerPhone}";
    }
}