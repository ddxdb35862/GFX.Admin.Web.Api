namespace ET;

public class GridHelper
{
    
    public static List<Vector2Int> SplitGridInItem(string gridArrayStr)
    {
        string[] gridArrays = gridArrayStr.Split(",");
        List<Vector2Int> gridList = new List<Vector2Int>();
        foreach (string gridArray in gridArrays)
        {
            string[] gridXY = gridArray.Split("-");
            gridList.Add(new Vector2Int(int.Parse(gridXY[0]), int.Parse(gridXY[1])));
        }
        return gridList;
    }
}