using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsControlLibrary4;

namespace InterfaceDesigner
{
    public partial class UserText : WindowsFormsControlLibrary4.UserText
    {
        public string accessibleDefaultActionDescription;
        public string accessibleDescription;
        public string accessibleName;
        public AccessibleRole accessibleRole;
        public bool allowDrop;
        public AnchorStyles anchor;
        public Point autoScrollOffset;
        public Color backColor;
        public Image backgroundImage;
        public ImageLayout backgroundImageLayout;
        //public BindingContext bindingContext;
        public int bottom;
        public Rectangle bounds;
        public bool canFocus;
        public bool canSelect;
        public bool capture;
        public bool causesValidation;
        public Rectangle clientRectangle;
        public Size clientSize;
        public string companyName;
        public IContainer container;
        public bool containsFocus;
        //public string contextMenu;
        public string contextMenuStrip;
        public string controls;
        public bool created;
        public Cursor cursor;
        //public string DataBindings;
        public Rectangle displayRectangle;
        //public bool Disposing;
        public DockStyle dockStyle;
        public bool enabled;
        public FlatStyle flatStyle;
        public bool focused;
        public Font font;
        public Color foreColor;
        public IntPtr handle;
        public bool hasChildren;
        public int height;
        public Image image;
        public ImeMode imeMode;
        public bool invokeRequired;
        public bool isAccessible;
        public bool isDisposed;
        public bool isHandleCreated;
        public bool isMirrored;
        //public string LayoutEngine;
        public int left;
        public Point location;
        public Padding margin;
        public Size maximumSize;
        public Size minimumSize;
        public string name;
        public Padding padding;
        public string parent;
        public PictureBoxSizeMode sizeMode;
        public Size preferredSize;
        public string productName;
        public string productVersion;
        public bool recreatingHandle;
        //public Region region;
        public int right;
        public string rightToLeft;
        //public string site;
        public Size size;
        public int tabIndex;
        public bool tabStop;
        public object tag;
        public string text;
        public ContentAlignment textAlign;
        public int top;
        public string topLevelControl;
        public bool useWaitCursor;
        public bool visible;
        public int width;
        public UserText()
        {
            InitializeComponent();
        }
    }
}
