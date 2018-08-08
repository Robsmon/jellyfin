// This code is derived from jcifs smb client library <jcifs at samba dot org>
// Ported by J. Arturo <webmaster at komodosoft dot net>
//  
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
using System.IO;
using SharpCifs.Util.Sharpen;

namespace SharpCifs.Smb
{
	internal class NtTransQuerySecurityDescResponse : SmbComNtTransactionResponse
	{
		internal SecurityDescriptor SecurityDescriptor;

	    internal override int WriteSetupWireFormat(byte[] dst, int dstIndex)
		{
			return 0;
		}

		internal override int WriteParametersWireFormat(byte[] dst, int dstIndex)
		{
			return 0;
		}

		internal override int WriteDataWireFormat(byte[] dst, int dstIndex)
		{
			return 0;
		}

		internal override int ReadSetupWireFormat(byte[] buffer, int bufferIndex, int len
			)
		{
			return 0;
		}

		internal override int ReadParametersWireFormat(byte[] buffer, int bufferIndex, int
			 len)
		{
			Length = ReadInt4(buffer, bufferIndex);
			return 4;
		}

		internal override int ReadDataWireFormat(byte[] buffer, int bufferIndex, int len)
		{
			int start = bufferIndex;
			if (ErrorCode != 0)
			{
				return 4;
			}
			try
			{
				SecurityDescriptor = new SecurityDescriptor();
				bufferIndex += SecurityDescriptor.Decode(buffer, bufferIndex, len);
			}
			catch (IOException ioe)
			{
				throw new RuntimeException(ioe.Message);
			}
			return bufferIndex - start;
		}

		public override string ToString()
		{
			return "NtTransQuerySecurityResponse[" + base.ToString() + "]";
		}
	}
}