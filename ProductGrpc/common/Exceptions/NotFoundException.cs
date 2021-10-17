
using System;

namespace ProductGrpc.common.Exceptions;
public class NotFoundException: Exception
{

    public NotFoundException(string message): base (message)
    {

    }
}
