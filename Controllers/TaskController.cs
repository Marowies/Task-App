using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskApp.Dtos;
using TaskApp.Models;
using TaskApp.SAL;

namespace TaskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;
        private readonly IMapper _mapper;

        public TaskController(TaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = _taskService.GetAll();
            var tasksDto = _mapper.Map<IEnumerable<TaskReadDto>>(tasks);
            return Ok(tasksDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _taskService.GetByIdAsync(id);
          if (task == null)
                throw new Exception("Task not found");

            var taskDto = _mapper.Map<TaskReadDto>(task);
            return Ok(taskDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskCreateDto taskCreateDto)
        {
            var taskModel = _mapper.Map<TaskItem>(taskCreateDto);
            var createdTask = await _taskService.CreateAsync(taskModel);
            var taskReadDto = _mapper.Map<TaskReadDto>(createdTask);
            return Ok(taskReadDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaskUpdateDto taskUpdateDto)
        {
            var existingTask = await _taskService.GetByIdAsync(id);
            if (existingTask == null)
                return NotFound($"No task found with ID = {id}");

            _mapper.Map(taskUpdateDto, existingTask);
            await _taskService.UpdateAsync(existingTask);

            return Ok("Task updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _taskService.DeleteAsync(id);
            if (!result)
                return NotFound("Task not found.");

            return NoContent();
        }
    }
}
