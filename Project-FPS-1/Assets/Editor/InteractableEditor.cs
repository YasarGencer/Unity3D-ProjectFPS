using UnityEditor;

[CustomEditor(typeof(Interactable), true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI(){
        Interactable interactable = (Interactable)target;
        //if target is event only
        if(target.GetType() == typeof(EventOnlyInteractable)){
            //create a promt message component
            interactable.promptMessage = EditorGUILayout.TextField("Prompt Mesaage", interactable.promptMessage);
            EditorGUILayout.HelpBox("EventOnlyInteract can ONLY use UnityEvents.", MessageType.Info);
            //add event clicks
            if(interactable.GetComponent<InteractionEvents>() == null){
                interactable.UseEvent = true;
                interactable.gameObject.AddComponent<InteractionEvents>();
            }
        }
        else{
            base.OnInspectorGUI();
            //add event clicks
            if(interactable.UseEvent){
                if(interactable.GetComponent<InteractionEvents>() == null)    
                    interactable.gameObject.AddComponent<InteractionEvents>();
            }
            //remove event clicks
            else{
                if(interactable.GetComponent<InteractionEvents>() == null)
                    DestroyImmediate(interactable.GetComponent<InteractionEvents>());
            }
        }
    
    }
}
