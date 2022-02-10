using Infrastructure.DataBase;
using System.Threading.Tasks;

namespace MyCompany
{
    public delegate Task MakeDbDelegate(DataBaseContext dataBase);
}
