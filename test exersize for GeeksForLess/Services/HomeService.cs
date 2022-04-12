using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_exersize_for_GeeksForLess.Models.HomeModels;

namespace test_exersize_for_GeeksForLess.Services
{
    public interface IHomeService
    {
        void FillIndexModel(HomeIndexModel model);
    }
    public class HomeService: IHomeService
    {
        private readonly ApplicationContext _repository;

        public HomeService(ApplicationContext repository)
        {
            _repository = repository;
        }

        public void FillIndexModel(HomeIndexModel model)
        {
            model.Topics = _repository.Topics;
        }
    }
}
