using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rene
{
    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Reflection;
    using System.Text;
    using System.Threading;

    public class StackTraceList : StackTrace, IList
    {
        public StackTraceList()
            : base()
        {
            InitInternalFrameArray();
        }

        public StackTraceList(bool needFileInfo)
            : base(needFileInfo)
        {
            InitInternalFrameArray();
        }

        public StackTraceList(Exception e)
            : base(e)
        {
            InitInternalFrameArray();
        }

        public StackTraceList(int skipFrames)
            : base(skipFrames)
        {
            InitInternalFrameArray();
        }

        public StackTraceList(StackFrame frame)
            : base(frame)
        {
            InitInternalFrameArray();
        }

        public StackTraceList(Exception e, bool needFileInfo)
            : base(e, needFileInfo)
        {
            InitInternalFrameArray();
        }

        public StackTraceList(Exception e, int skipFrames)
            : base(e, skipFrames)
        {
            InitInternalFrameArray();
        }

        public StackTraceList(int skipFrames, bool needFileInfo) :
            base(skipFrames, needFileInfo)
        {
            InitInternalFrameArray();
        }

        public StackTraceList(Thread targetThread, bool needFileInfo) :
            base(targetThread, needFileInfo)
        {
            InitInternalFrameArray();
        }

        public StackTraceList(Exception e, int skipFrames, bool needFileInfo) :
            base(e, skipFrames, needFileInfo)
        {
            InitInternalFrameArray();
        }

        private StackFrame[] internalFrameArray = null;

        private void InitInternalFrameArray()
        {
            internalFrameArray = new StackFrame[base.FrameCount];

            for (int counter = 0; counter < base.FrameCount; counter++)
            {
                internalFrameArray[counter] = base.GetFrame(counter);
            }
        }

        public string GetFrameAsString(int index)
        {
            StringBuilder str = new StringBuilder("\tat ");
            str.Append(GetFrame(index).GetMethod().DeclaringType.FullName);
            str.Append(".");
            str.Append(GetFrame(index).GetMethod().Name);
            str.Append("(");
            foreach (ParameterInfo PI in GetFrame(index).GetMethod().GetParameters())
            {
                str.Append(PI.ParameterType.Name);
                if (PI.Position <
                    (GetFrame(index).GetMethod().GetParameters().Length - 1))
                {
                    str.Append(", ");
                }
            }
            str.Append(")");

            return (str.ToString());
        }

        // IList properties/methods
        public bool IsFixedSize
        {
            get { return (internalFrameArray.IsFixedSize); }
        }

        public bool IsReadOnly
        {
            get { return (true); }

        }

        // Note that this indexer must return an object to comply
        // with the IList interface for this indexer.
        public object this[int index]
        {
            get { return (internalFrameArray[index]); }
            set
            {
                throw (new NotSupportedException(
                    "The set indexer method is not supported on this object."));
            }
        }

        public int Add(object value)
        {
            return (((IList)internalFrameArray).Add(value));
        }

        public void Insert(int index, object value)
        {
            ((IList)internalFrameArray).Insert(index, value);
        }

        public void Remove(object value)
        {
            ((IList)internalFrameArray).Remove(value);
        }

        public void RemoveAt(int index)
        {
            ((IList)internalFrameArray).RemoveAt(index);
        }

        public void Clear()
        {
            // Throw an exception here to prevent the loss of data.
            throw (new NotSupportedException(
                "The Clear method is not supported on this object."));
        }

        public bool Contains(object value)
        {
            return (((IList)internalFrameArray).Contains(value));
        }

        public int IndexOf(object value)
        {
            return (((IList)internalFrameArray).IndexOf(value));
        }

        // IEnumerable method
        public IEnumerator GetEnumerator()
        {
            return (internalFrameArray.GetEnumerator());

        }

        // ICollection properties/methods
        public int Count
        {
            get { return (internalFrameArray.Length); }
        }

        public bool IsSynchronized
        {
            get { return (internalFrameArray.IsSynchronized); }
        }

        public object SyncRoot
        {
            get { return (internalFrameArray.SyncRoot); }
        }

        public void CopyTo(Array array, int index)
        {
            internalFrameArray.CopyTo(array, index);
        }
    }
}
