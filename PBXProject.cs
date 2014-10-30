using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UnityEditor.XCodeEditor
{
	public class PBXProject : PBXObject
	{
		protected string MAINGROUP_KEY = "mainGroup";
		
		public PBXProject() : base() {
		}
		
		public PBXProject( string guid, PBXDictionary dictionary ) : base( guid, dictionary ) {	
		}
		
		public string mainGroupID {
			get {
				return (string)_data[ MAINGROUP_KEY ];
			}
		}

		public void AddKnownRegion(string region)
		{
			if (string.IsNullOrEmpty(region)) {
				return;
			}

			if (System.Text.RegularExpressions.Regex.IsMatch(region, "[a-z]{2}[_-][a-z]{2}", System.Text.RegularExpressions.RegexOptions.IgnoreCase)) {
				region = "\"" + region.Replace("_", "-") + "\"";
			}

			PBXList _list = (PBXList)this.data["knownRegions"];
			if (!_list.Contains(region)) {
				_list.Add(region);
			}
		}

		public void RemoveKnownRegion(string region)
		{
			if (string.IsNullOrEmpty(region)) {
				return;
			}

			if (System.Text.RegularExpressions.Regex.IsMatch(region, "[a-z]{2}[_-][a-z]{2}", System.Text.RegularExpressions.RegexOptions.IgnoreCase)) {
				region = "\"" + region.Replace("_", "-") + "\"";
			}

			PBXList _list = (PBXList)this.data["knownRegions"];
			if (_list.Contains(region)) {
				_list.Remove(region);
			}
		}

		public void RemoveKnownRegionAll()
		{
			// やや強引だが、全部消しちゃうと動かなくなるので、初期値として英語を追加しておく
			this.data["knownRegions"] = new PBXList("en");
		}
	}
}
