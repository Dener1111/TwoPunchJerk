using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    // TODO: decouple to ToggleLayerBehaviour
    //and ParameterBehaviour
    public class LayerWeightBehaviour : StateMachineBehaviour
    {
        [SerializeField] Mode mode = Mode.Both;
        
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if(mode == Mode.DisableOnExit)
                return;
            
            animator.SetLayerWeight(layerIndex, 1f);
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if(mode == Mode.EnableOnEnter)
                return;
            
            animator.SetLayerWeight(layerIndex, 0f);
        }

        enum Mode
        {
            Both,
            EnableOnEnter,
            DisableOnExit
        }
    }
}
