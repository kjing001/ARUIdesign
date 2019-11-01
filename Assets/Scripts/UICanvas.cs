using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour
{
    // UI 
    public Button editButton;
    public Button clearButton;
    public GameObject editPanel;
    public InputField nameInput;
    public InputField ideaInput;
    public InputField[] skillInputs;
    public InputField[] teamInputs;

    public Action onNameChanged;
    public Action onIdeaChanged;
    public Action onSkillsChanged;
    public Action onTeamChanged;

    public List<UIBadge> badges;

    public static UICanvas instance;

    public string NickName { get { return nameInput.text; } }
    public string Idea {get {return ideaInput.text;}}
    public string Skills
    {
        get
        {
            string s = "";
            foreach (var item in skillInputs)
                s += item.text + " ";
            return s.Trim();
        }
    }
    public string Team
    {
        get
        {
            string s = "";
            foreach (var item in teamInputs)
                s += item.text + " ";
            return s.Trim();
        }
    }

    public void AddBadge(UIBadge badge)
    {
        if (badges.Contains(badge))
            return;
        badges.Add(badge);
    }

    public void RemoveBadge(UIBadge badge)
    {
        if (badges.Contains(badge))        
            badges.Remove(badge);        
    }

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        editButton.onClick.AddListener(OnEditClick);
        clearButton.onClick.AddListener(OnClearClick);
        nameInput.onValueChanged.AddListener(delegate { OnNameChanged(); });
        ideaInput.onValueChanged.AddListener(delegate { OnIdeaChanged(); });

        foreach (InputField inputField in skillInputs)
            inputField.onValueChanged.AddListener(delegate { OnSkillsChanged(); });

        foreach (InputField inputField in teamInputs)
            inputField.onValueChanged.AddListener(delegate { OnTeamChanged(); });
    }

    private void OnClearClick()
    {
        if (badges == null || badges.Count == 0)
            return;

        foreach (var item in badges)        
            Destroy(item.gameObject);
        
        badges = new List<UIBadge>();
    }

    private void OnEditClick()
    {
        editPanel.SetActive(!editPanel.activeSelf);
    }
    public void OnNameChanged()
    {
        if (badges == null || badges.Count == 0)
            return;

        foreach (var item in badges)        
            item.NickName = nameInput.text;        
    }

    public void OnIdeaChanged()
    {
        if (badges == null || badges.Count == 0)
            return;

        foreach (var item in badges)
            item.Idea = ideaInput.text;
        
    }
    public void OnSkillsChanged()
    {
        if (badges == null || badges.Count == 0)
            return;

        string s = Skills;
        foreach (var item in badges)        
            item.Skills = s;        
    }

    public void OnTeamChanged()
    {
        if (badges == null || badges.Count == 0)
            return;

        string s = Team;
        foreach (var item in badges)        
            item.Team = s;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
