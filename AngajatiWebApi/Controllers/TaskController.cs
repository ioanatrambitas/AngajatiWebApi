using System;
using AngajatiWebApi.Entities;
using AngajatiWebApi.ExternalModels;
using AngajatiWebApi.Services.UnitsOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AngajatiWebApi.Controllers
{
    [Route("task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskUnitOfWork _taskUnit;
        private readonly IMapper _mapper;

        public TaskController(ITaskUnitOfWork taskUnit,
            IMapper mapper)
        {
            _taskUnit = taskUnit ?? throw new ArgumentNullException(nameof(taskUnit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #region Tasks
        [HttpGet]
        [Route("{id}", Name = "Task")]
        public IActionResult GetTask(Guid id)
        {
            var taskEntity = _taskUnit.Tasks.Get(id);
            if (taskEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TaskDTO>(taskEntity));
        }

        [HttpGet]
        [Route("details/{id}", Name = "GetTaskDetails")]
        public IActionResult GetTaskDetails(Guid id)
        {
            var taskEntity = _taskUnit.Tasks.GetTaskDetails(id);
            if (taskEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TaskDTO>(taskEntity));
        }

        [Route("add", Name = "Add a new task")]
        [HttpPost]
        public IActionResult AddTak([FromBody] TaskDTO task)
        {
            var taskEntity = _mapper.Map<Task>(task);
            _taskUnit.Tasks.Add(taskEntity);

            _taskUnit.Complete();

            _taskUnit.Tasks.Get(taskEntity.ID);

            return CreatedAtRoute("GetTask",
                new { id = taskEntity.ID },
                _mapper.Map<TaskDTO>(taskEntity));
        }
        #endregion Tasks
        
        #region Trainings
        [HttpGet]
        [Route("training/{trainingId}", Name = "GetTraining")]
        public IActionResult GetTraining(Guid trainingId)
        {
            var trainingEntity = _taskUnit.Trainings.Get(trainingId);
            if (trainingEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TrainingDTO>(trainingEntity));
        }
        
        [HttpGet]
        [Route("training", Name = "GetAllTrainings")]
        public IActionResult GetAllTrainings()
        {
            var trainingEntities = _taskUnit.Trainings.Find(a => a.Deleted == false || a.Deleted == null);
            if (trainingEntities == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<TrainingDTO>>(trainingEntities));
        }

        [Route("training/add", Name = "Add a new training")]
        [HttpPost]
        public IActionResult AddTraining([FromBody] TrainingDTO training)
        {
            var trainingEntity = _mapper.Map<Training>(training);
            _taskUnit.Trainings.Add(trainingEntity);

            _taskUnit.Complete();

            _taskUnit.Trainings.Get(trainingEntity.ID);

            return CreatedAtRoute("GetTraining",
                new { trainingId = trainingEntity.ID },
                _mapper.Map<TrainingDTO>(trainingEntity));
        }

        [Route("training/{trainingId}", Name = "Mark training as deleted")]
        [HttpPut]
        public IActionResult MarkTrainingAsDeleted(Guid trainingId)
        {
            var training = _taskUnit.Trainings.FindDefault(a => a.ID.Equals(trainingId) && (a.Deleted == false || a.Deleted == null));
            if (training != null)
            {
                training.Deleted = true;
                if (_taskUnit.Complete() > 0)
                {
                    return Ok("Training " + trainingId + " was deleted.");
                }
            }
            return NotFound();
        }
        #endregion Trainings
    
    }
}