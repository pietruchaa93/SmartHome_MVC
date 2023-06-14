using SmartHome_Database;

namespace SmartHome_MVC
{
    public class DevicesManager
    {
        private string _selectedPortCOM;

        public string GetLastSelectedPortCOM()
        {
            var dbContext = new SmartHomeDbContext();
            var lastSave = dbContext.selectportCOM
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            if (lastSave != null)
            {
                int id = lastSave.Id;
                return lastSave.portCOM;
            }

            return null;
        }

        public void SetSelectedPortCOM(string portCOM)
        {
            _selectedPortCOM = portCOM;

            var dbContext = new SmartHomeDbContext();
            dbContext.selectportCOM.Add(new SelectedPort
            {
                portCOM = portCOM,
            });
            dbContext.SaveChanges();
        }
    }
}
