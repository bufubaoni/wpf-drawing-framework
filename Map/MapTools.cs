using System.Windows.Input;

namespace Map
{
    public enum CommandType { None, Pan, Scale, WindowMax, WindowMin, Pick, Select, ReverseSelect }
    public abstract class MapTools
    {
        public CommandType m_CommandType;
        public Cursor Cursor;
        public DragType DragShape;
        //记录鼠标位置
        static public System.Windows.Point CurrentMouseScreenPosition;
        static public System.Windows.Point CurrentMouseMapPosition;
        static public System.Windows.Point MouseDownMapPosition;
        static public System.Windows.Point MouseUpMapPosition;
        static public System.Windows.Point MouseDownScreenPosition;
        static public System.Windows.Point MouseUpScreenPosition;
        //正在执行的命令
        static public Cursor DefaultCursor;
        static public MapTools CurrentCommand = null;
        static public MainCanvas Canvas;

        public virtual void MouseLeftButtonDown() { }
        public virtual void MouseLeftButtonUp() { }
        public virtual void MouseMove() { }

        public virtual bool CommandEnded()
        {
            return true;
        }

        public virtual void CommandStarted() { }

        static public void StartCommand(MapTools mapTools, MainCanvas mainCanvas)
        {
            CurrentCommand = mapTools;
            Canvas = mainCanvas;
            Canvas.Cursor = mapTools.Cursor;
        }

        static public void EndCommand()
        {
            if (Canvas != null)
            {
                Canvas.Cursor = DefaultCursor;
            }
            DragLine.CurrentDrag.End();
        }

        static public void OnMouseLeftButtonDown()
        {
            if (CurrentCommand != null) CurrentCommand.MouseLeftButtonDown();
        }

        static public void OnMouseMove()
        {
            if (CurrentCommand != null) CurrentCommand.MouseMove();
        }

        static public void OnMouseLeftButtonUp()
        {
            if (CurrentCommand != null) CurrentCommand.MouseLeftButtonUp();
        }

        protected MapTools()
        {
            m_CommandType = CommandType.None;
            Cursor = Cursors.Cross;
            DragShape = DragType.None;
        }

    }
}
