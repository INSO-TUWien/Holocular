using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Handles;

public class FileController : MonoBehaviour
{
    public string fullFilePath = "";
    public string fileName = "";
    public DBCommitFileRelation commitFileRelation;
    public List<HelixCommitFileStakeholderRelation> commitFileStakeholderRelationList;
    public DBCommit commit;

    public string owner;
    public int linesOwned = 0;
    public int lines = 0;

    public GameObject visual;

    private Material mat;

    private UnityAction updateFileColorListener;


    // Start is called before the first frame update
    void Start()
    {
        mat = visual.GetComponent<Renderer>().material;
        updateFileColorListener = new UnityAction(ChangeColor);
        EventManager.StartListening("updateFileColor", updateFileColorListener);

    }

    public void Init()
    {
        for (int i = 0; i < commitFileStakeholderRelationList.Count; i++)
        {
            lines += commitFileStakeholderRelationList[i].dBCommitsFilesStakeholderStore.ownedLines;
            if (commitFileStakeholderRelationList[i].dBCommitsFilesStakeholderStore.ownedLines > linesOwned)
            {
                linesOwned = commitFileStakeholderRelationList[i].dBCommitsFilesStakeholderStore.ownedLines;
                owner = commitFileStakeholderRelationList[i].helixStakeholderStore.dBStakeholderStore.gitSignature;
            }
        }
        ChangeColor();
    }

    private void ChangeColor()
    {
        if (GlobalSettings.showAuthorColors && (GlobalSettings.highlightedAuthor == null || GlobalSettings.highlightedAuthor == commit.signature))
        {
            mat.color = Main.helix.stakeholders[commit.signature].colorStore;
        }
        else if (GlobalSettings.showOwnershipColors && owner != "" && (GlobalSettings.highlightedAuthor == null || GlobalSettings.highlightedAuthor == owner))
        {
            mat.color = Main.helix.stakeholders[owner].colorStore;
        }
        else if (GlobalSettings.showBranchColors && (GlobalSettings.highlightedBranch == null || GlobalSettings.highlightedBranch == commit.branch))
        {
            mat.color = Main.helix.branches[commit.branch].colorStore;
        }
        else if (GlobalSettings.showAuthorColors || GlobalSettings.showOwnershipColors || GlobalSettings.showBranchColors)
        {
            mat.color = Main.fileDeSelectedColor;
        }
        else
        {
            mat.color = Main.fileDefaultColor;
        }
    }
}
