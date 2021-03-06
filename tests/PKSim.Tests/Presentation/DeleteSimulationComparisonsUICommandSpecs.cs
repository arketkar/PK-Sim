﻿using System.Collections.Generic;
using FakeItEasy;
using OSPSuite.BDDHelper;
using PKSim.Core.Chart;
using PKSim.Core.Model;
using PKSim.Core.Services;
using PKSim.Presentation.UICommands;

namespace PKSim.Presentation
{
   public abstract class concern_for_DeleteSimulationComparisonsUICommand : ContextSpecification<DeleteSimulationComparisonsUICommand>
   {
      protected ISimulationComparisonTask _simulationComparisonTask;
      private ISimulationComparison _individualSimulationComparison;
      protected IReadOnlyList<ISimulationComparison> _simulationComparisonToDelete;

      protected override void Context()
      {
         _individualSimulationComparison = new IndividualSimulationComparison();
         _simulationComparisonTask = A.Fake<ISimulationComparisonTask>();
         _simulationComparisonToDelete= new[] {_individualSimulationComparison};
         sut = new DeleteSimulationComparisonsUICommand(_simulationComparisonTask) {Subject = _simulationComparisonToDelete };
      }

      protected override void Because()
      {
         sut.Execute();
      }
   }

   public class When_the_user_is_executing_the_delete_simulation_comparison_command : concern_for_DeleteSimulationComparisonsUICommand
   {
      [Observation]
      public void should_leverage_the_simulation_comparison_task_to_delete_the_simulation_comparisons()
      {
         A.CallTo(() => _simulationComparisonTask.Delete(_simulationComparisonToDelete)).MustHaveHappened();
      }
   }
}