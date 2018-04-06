using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "AI/Decision/ActiveState")]
public class AktifState : Decision 
{
	public override bool Decide (StateController controller)
	{
		bool chaseTargetIsActive = controller.chaseTarget.gameObject.activeSelf;
		return chaseTargetIsActive;
	}
}