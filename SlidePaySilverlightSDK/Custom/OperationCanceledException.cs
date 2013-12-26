using System;
using System.Net;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Microsoft.Http
{
  public class OperationCanceledException : Exception
  {
    public OperationCanceledException()
    {
    }

    public OperationCanceledException(string message) : base(message)
    {
    }

    public OperationCanceledException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}
