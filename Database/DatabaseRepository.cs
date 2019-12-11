using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class DatabaseRepository : IDatabaseRepository
    {
        DatabaseContext ctx = new DatabaseContext();
        private readonly object Lock = new object();


        public void Add(UserMeter newUserMeter)
        {
            UserMeter oldUserMeter;
            lock (Lock)
            {
                if ((oldUserMeter = ctx.UserMeters.Find(newUserMeter.Id)) != null)
                    throw new Exception($"Element with ID : {newUserMeter.Id} is already found in database.");
                else
                {
                    ctx.UserMeters.Add(newUserMeter);
                    ctx.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            UserMeter oldUserMeter;
            lock (Lock)
            {
                if ((oldUserMeter = ctx.UserMeters.Find(id)) == null)
                    throw new Exception($"Element with ID : {id} not found.");
                else
                {
                    ctx.UserMeters.Remove(oldUserMeter);
                    ctx.SaveChanges();
                }
            }
        }


        public void ModifyId(int oldId, int newId)
        {
            UserMeter oldUserMeter;
            lock (Lock)
            {
                if ((oldUserMeter = ctx.UserMeters.Find(oldId)) == null)
                    throw new Exception($"Element with ID : {oldId} not found.");
                else
                {
                    UserMeter newUserMeter = new UserMeter() { Id = newId, ElectricEnergy = oldUserMeter.ElectricEnergy, Name = oldUserMeter.Name };
                    Delete(oldId);
                    Add(newUserMeter);
                    ctx.SaveChanges();
                }
            }
        }

        public void ModifyValueOfElectricEnergy(int oldId, double newValue)
        {
            UserMeter oldUserMeter;
            lock (Lock)
            {
                if ((oldUserMeter = ctx.UserMeters.Find(oldId)) == null)
                    throw new Exception($"Element with ID : {oldId} not found.");
                else
                {
                    oldUserMeter.ElectricEnergy = newValue;
                    ctx.SaveChanges();
                }
            }
        }
    }
}
