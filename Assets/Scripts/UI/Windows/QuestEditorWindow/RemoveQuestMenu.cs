﻿using Assets.Scripts.UI;
using Assets.Scripts.UI.Windows;
using UnityEngine;
using UnityEngine.UI;

public class RemoveQuestMenuParams : WindowParams
{
    public string id;
}

public class RemoveQuestMenu : BaseWindow {

    [SerializeField] private Text _errorText;
    [SerializeField] private Text _idText;

    string _id;

    public static void Show(string id_)
    {
        RemoveQuestMenuParams params_ = new RemoveQuestMenuParams() { id = id_ };
        App.UI.Show("RemoveQuestMenu", params_);
    }

    public override void OnShowComplete(WindowParams param_ = null)
    {
        base.OnShowComplete(param_);
        _id = (windowsParameters as RemoveQuestMenuParams).id;
        _idText.text = "id: "+_id;
    }

    public void OnCancelClick()
    {
        Hide();
    }

    public void OnRemoveClick()
    {
        RemoveQuestMenuParams params_ = windowsParameters as RemoveQuestMenuParams;

        if (App.Data.Steps.Get(params_.id) == null)
        {
            _errorText.text = "id is not exists!";
            return;
        }
        
        
        App.Data.Steps.Remove(params_.id, true);
        Hide();
    }
}
