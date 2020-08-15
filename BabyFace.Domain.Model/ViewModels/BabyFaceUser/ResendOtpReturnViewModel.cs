using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyFace.Domain.Model.ViewModels.BabyFaceUser
{
  public class ResendOtpReturnViewModel
  {
    public bool IsSent { get; set; }
    public long CurrentTimeStamp { get; set; }
    public long OtpExpiationTimeStamp { get; set; }
  }
}
