using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VcmSuite3x.Application.ViewModel;

namespace VcmSuite3x.Application.Interface
{
    public interface INoAppService
    {
        NoViewModel Create(int id, int topologiaId, IMapper _mapper);
    }
}
