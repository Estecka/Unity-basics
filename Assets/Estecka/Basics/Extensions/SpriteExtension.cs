using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace Estecka.Extensions{
	static public class SpriteSheetExtension {

		static readonly ReadOnlyCollection<Sprite> empty = new ReadOnlyCollection<Sprite>(new Sprite[0]);
		static readonly Dictionary<Texture2D, ReadOnlyCollection<Sprite>> _cache = new Dictionary<Texture2D, ReadOnlyCollection<Sprite>>();

		/// <summary>
		/// Clears the cache for lists of sprites per sheet;
		/// </summary>
		static public void ClearCache(){
			_cache.Clear();
		}

		/// <summary>
		/// Find the sprites contained in this spritesheet. 
		/// The texture must be placed at the root of a 'Resource' folder.
		/// </summary>
		static public ReadOnlyCollection<Sprite> GetSprites(this Texture2D sheet){
			if (sheet == null)
				throw new System.ArgumentNullException("Spritesheet cannot be null");
			if (_cache.ContainsKey(sheet))
				return _cache[sheet];
			
			Sprite[] sprites = null;
			Texture2D res = Resources.Load<Texture2D>(sheet.name);
			if (res == null || res != sheet){
				Debug.LogError("The spritesheet must be placed into a resource folder.", sheet);
				return empty;
			}

			sprites = Resources.LoadAll<Sprite>(sheet.name);
			_cache[sheet] = new ReadOnlyCollection<Sprite>(sprites);

			return _cache[sheet];
		}

		/// <summary>
		/// Find a sprite with the given name in this spritesheet.
		/// The texture must be placed at the root of a 'Resource' folder.
		/// </summary>
		static public Sprite GetSprite(this Texture2D sheet, string @name){
			if (name == null)
				throw new System.ArgumentNullException("Name cannot be null");
			var sprites = GetSprites(sheet);
			return
				(from s in sprites
				where s.name == @name
				select s)
				.SingleOrDefault();
		}

	} // END Extension
} // END Namespace