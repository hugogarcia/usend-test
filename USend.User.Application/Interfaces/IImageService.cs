using System.Threading.Tasks;

namespace USend.UserApi.Application.Interfaces
{
    public interface IImageService
    {
        void WriteFileOnDisk(string base64File, string fileName);
        string FindImageUrl(string fileName);
    }
}
