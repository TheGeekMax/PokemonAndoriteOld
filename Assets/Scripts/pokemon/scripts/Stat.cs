using UnityEngine;

//classe changement, contient les outils pour ajouter un stats au status
[System.Serializable]
public class Stat{
	public float percentage = .5f;
	public int nbTours = -1;

	//choix
	public ChangeParams changeParams;
}

[System.Serializable]
public class IgStat{
	public float percentage = .5f;
	public int nbTours = -1;

	//choix
	public IgChangeParams igChangeParams;
}


//parametres du changement de stats
[System.Serializable]
public class ChangeParams{
	public enum ChangeType{
    	hp,
    	precision,
    	vitesse
    }
	public ChangeType typeChg;
	public float mult = .5f;
}

[System.Serializable]
public class IgChangeParams{
	public enum ChangeType{
    	noAtt,
    	attraction,
    	lifeTransfer
    }
	public ChangeType typeChg;
}
