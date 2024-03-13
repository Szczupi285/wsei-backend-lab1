namespace BlazorChat
{
    public class UserService
    {
        public Dictionary<string,string> Users = new Dictionary<string, string>();
        public void Add(string connectionId, string username) => Users.Add(connectionId, username); 

        public void RemoveByName(string username)
        {
           var keyValuePair =  Users.First(x => x.Value == username);
           Users.Remove(keyValuePair.Key);
        }
        
        public string GetConnectionIdByName(string username)
        {
            var keyValuePair = Users.First(x => x.Value == username);
            return keyValuePair.Key;
        }
        public Dictionary<string, string> GetAll()
        {
            return Users;
        }
    }
}
