using UnityEngine;
using UnityEngine.UI;

public class ElectionManager : MonoBehaviour
{
    [System.Serializable]
    public class Candidate
    {
        public string Name;           // 候補者名
        public string Manifesto;      // 公約内容
        public int TaxChange;         // 税率の変化
        public int PensionChange;     // 年金の影響
        public Sprite CharacterImage; // 候補者画像
    }

    public Candidate[] candidates;   // 候補者データの配列
    public Text manifestoText;       // 公約表示テキスト
    public Text resultText;          // 結果表示テキスト
    public Image candidateImage;     // 候補者画像表示
    public Image resultImage;        // 結果画像表示

    private int selectedCandidateIndex = -1;

    void Start()
    {
        DisplayManifesto(-1); // 初期状態では何も選択しない
    }

    public void DisplayManifesto(int index)
    {
        if (index >= 0 && index < candidates.Length)
        {
            selectedCandidateIndex = index;
            manifestoText.text = $"候補者: {candidates[index].Name}\n\n公約: {candidates[index].Manifesto}";
            candidateImage.sprite = candidates[index].CharacterImage;
            candidateImage.enabled = true; // 画像を表示
        }
        else
        {
            manifestoText.text = "候補者を選択してください。";
            candidateImage.enabled = false; // 画像を非表示
        }
    }

    public void Vote()
    {
        if (selectedCandidateIndex >= 0)
        {
            Candidate chosenCandidate = candidates[selectedCandidateIndex];
            resultText.text = $"あなたは {chosenCandidate.Name} に投票しました！\n" +
                              $"結果: 税率 {chosenCandidate.TaxChange}%、年金 {chosenCandidate.PensionChange}。";

            resultImage.sprite = chosenCandidate.CharacterImage;
            resultImage.enabled = true; // 結果画像を表示
            ApplyChanges(chosenCandidate);
        }
        else
        {
            resultText.text = "候補者を選択してください。";
            resultImage.enabled = false; // 結果画像を非表示
        }
    }

    private void ApplyChanges(Candidate candidate)
    {
        // 社会への影響を反映（例: ゲーム全体のステータス更新）
        Debug.Log($"税率変更: {candidate.TaxChange}, 年金影響: {candidate.PensionChange}");
    }
}
