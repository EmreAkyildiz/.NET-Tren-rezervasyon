using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Results;
using Entity;

namespace Business.Abstract
{
    public interface ITrainService
    {
        IDataResult<List<UygunVagon>> Reserve(Root root);

    }
}
