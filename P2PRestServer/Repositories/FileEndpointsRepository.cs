using P2PRestServer.Models;

namespace P2PRestServer.Repositories;

public class FileEndpointsRepository
{
    private Dictionary<string, List<FileEndPoint>> _data;
    
    public FileEndpointsRepository()
    {
        _data = new Dictionary<string, List<FileEndPoint>>();
    }
    
    public void AddFileEndPoint(string filename, FileEndPoint fileEndPoint)
    {
        if (!_data.ContainsKey(filename))
        {
            _data[filename] = new List<FileEndPoint>();
        }
        _data[filename].Add(fileEndPoint);
    }
    
    public List<FileEndPoint> GetFileEndPoints(string filename)
    {
        if (_data.ContainsKey(filename))
        {
            return _data[filename];
        }
        return new List<FileEndPoint>();
    }
    
    public void RemoveFileEndPoint(string filename, FileEndPoint fileEndPoint)
    {
        if (_data.ContainsKey(filename))
        {
            _data[filename].Remove(fileEndPoint);
            if (_data[filename].Count == 0)
            {
                _data.Remove(filename);
            }
        }
    }
    
    public List<string> GetAllFilenames()
    {
        return _data.Keys.ToList();
    }
}