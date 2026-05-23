namespace ProjectDumpTruck.MovementTemplate;

/// <summary>
/// Стратегия перемещения объекта к правой нижней границе экрана
/// </summary>
public class MoveToRightDownBorder : BaseTemplateMovement
{
    protected override bool IsTargetDestinaion()
    {
        ObjectCoordinates? objParams = GetObjectCoordinates();
        if (objParams is null)
        {
            return false;
        }
        bool isRightBorderReached = Math.Abs(objParams.RightBorder - FieldWidth) <= GetStep();
        bool isDownBorderReached = Math.Abs(objParams.DownBorder - FieldHeight) <= GetStep();
        return isRightBorderReached && isDownBorderReached;
    }
    protected override void MoveToTarget()
    {
        ObjectCoordinates? objParams = GetObjectCoordinates();
        if (objParams is null)
        {
            return;
        }
        int diffX = objParams.RightBorder - FieldWidth;
        if (Math.Abs(diffX) > GetStep())
        {
            if (diffX > 0)
            {
                MoveLeft();
            }
            else
            {
                MoveRight();
            }
        }
        int diffY = objParams.DownBorder - FieldHeight;
        if (Math.Abs(diffY) > GetStep())
        {
            if (diffY > 0)
            {
                MoveUp();
            }
            else
            {
                MoveDown();
            }
        }
    }
}