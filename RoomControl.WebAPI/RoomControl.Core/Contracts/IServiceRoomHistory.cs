﻿using RoomControl.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomControl.Core.Contracts
{
    public interface IServiceRoomHistory
    {
        Task AddAsync(int idRoom, int idState);
        Task<List<RoomHistory>> GetByDate(DateTime date);
    }
}
