using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBadge : MonoBehaviour
{
    Canvas canvas;
    Camera camera;
    public float badgeHeightOffset = 0.5f;

    public string defaultNickName = "Player";
    public string defaultSkills = "";
    public string defaultIdea = "";
    public string defaultTeam = "";

    public bool isLookingForTeam;

    public Text nameText;
    public Text ideaText;
    public Text skillText;
    public Text teamText;

    public string NickName;
    public string Idea;
    public string Skills;
    public string Team;

    // Start is called on the frame when a script is enabled just before any of the Update methods are called the first time.
    void Start()
    {
        camera = Camera.main;

        canvas = GetComponentInChildren<Canvas>();
        if (canvas.worldCamera == null)
            canvas.worldCamera = camera;
        canvas.transform.localPosition = new Vector3(0, badgeHeightOffset, 0);

        NickName = UICanvas.instance.NickName;
        Idea = UICanvas.instance.Idea;
        Skills = UICanvas.instance.Skills;
        Team = UICanvas.instance.Team;

        UICanvas.instance.AddBadge(this);
    }
    
    private void OnDestroy()
    {
        UICanvas.instance.RemoveBadge(this);
    }

    // Update is called once per frame
    void Update()
    {
        nameText.text = NickName;
        ideaText.text = Idea;
        skillText.text = Skills;
        teamText.text = Team;

        var target = canvas.transform.position * 2 - camera.transform.position;
        canvas.transform.LookAt(target);
    }
}
