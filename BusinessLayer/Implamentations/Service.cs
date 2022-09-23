using AutoMapper;
using BusinessLayer.Abstracts;
using DataAccessLayer.Abstracts;
using EntityLayer.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implamentations
{
    public class Service<TViewModel, TModel, Id> : IService<TViewModel, Id>
       where TViewModel : class, new()
       where TModel : class, new()
    {
        private readonly IRepository<TModel, Id> _repo;
        private readonly IMapper _mapper;
        private readonly string _includeEntities;

        public Service(IMapper mapper, IRepository<TModel, Id> repo,
            string includeEntities = null)
        {
            _mapper = mapper;
            _repo = repo;
            _includeEntities = includeEntities;
        }

        public IDataResult<TViewModel> Add(TViewModel model)
        {
            try
            {
                TModel tmodel = _mapper.Map<TViewModel, TModel>(model);
                bool result = _repo.Add(tmodel);
                TViewModel dataModel = _mapper.Map<TModel, TViewModel>(tmodel);

                return result ?
                    new SuccessDataResult<TViewModel>(dataModel, "Ekleme işlemi başarılı!")
                    : new ErrorDataResult<TViewModel>(dataModel, "DİKKAT! Ekleme işlemi başarısız!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IResult Delete(TViewModel model)
        {
            try
            {
                TModel mdl = _mapper.Map<TViewModel, TModel>(model);
                bool deleteResult = _repo.Delete(mdl);
                return deleteResult ? new SuccessResult("Silme işlemi başarılıdır!")
                : new ErrorResult("DİKKAT: Silme işlemi başarısız oldu!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IDataResult<ICollection<TViewModel>> GetAll(Expression<Func<TViewModel, bool>> filter = null)
        {
            try
            {
                var fltr = _mapper.Map<Expression<Func<TViewModel, bool>>,
                    Expression<Func<TModel, bool>>>(filter);
                var data = _repo.GetAll(fltr, includeEntities: _includeEntities);

                ICollection<TViewModel> dataList =
                    _mapper.Map<IQueryable<TModel>, ICollection<TViewModel>>(data);

                return new DataResult<ICollection<TViewModel>>(true, $"{dataList.Count} adet kayıt gönderildi", dataList);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IDataResult<TViewModel> GetByConditions(Expression<Func<TViewModel, bool>> filter = null)
        {
            try
            {
                var fltr = _mapper.Map<Expression<Func<TViewModel, bool>>, Expression<Func<TModel, bool>>>(filter);
                var data = _repo.GetByConditions(fltr, _includeEntities);
                if (data == null)
                {
                    throw new Exception("HATA: Kayıt bulunamadı!");
                }

                var mdl = _mapper.Map<TModel, TViewModel>(data);
                return new SuccessDataResult<TViewModel>(mdl, "Kayıt bulundu");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IDataResult<TViewModel> GetById(Id id)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception("HATA! id null olamaz!");
                }
                var data = _repo.GetById(id);
                if (data == null)
                {
                    throw new Exception("HATA! Kayıt bulunamadı!");
                }
                //ÖRN Product -->>ProductDTO
                var mdl = _mapper.Map<TModel, TViewModel>(data);
                return new SuccessDataResult<TViewModel>(mdl, $"{id} id'li kayıt bulundu!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IResult Update(TViewModel model)
        {
            try
            {
                TModel mdl = _mapper.Map<TViewModel, TModel>(model);
                var updateResult = _repo.Update(mdl);
                return updateResult ?
    new SuccessResult("Güncelleme işlemi başarılı!")
    : new ErrorResult("DİKKAT! Güncelleme işlemi başarısız!");

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
