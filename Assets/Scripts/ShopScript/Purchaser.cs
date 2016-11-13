using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

// Placing the Purchaser class in the CompleteProject namespace allows it to interact with ScoreManager, 
// one of the existing Survival Shooter scripts.

// Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
public class Purchaser : MonoBehaviour, IStoreListener
{

	public static Purchaser Instanse{ get; set; }
	private static IStoreController m_StoreController;          // The Unity Purchasing system.
	private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.
	public PlayerProfile plr;

	// Product identifiers for all products capable of being purchased: 
	// "convenience" general identifiers for use with Purchasing, and their store-specific identifier 
	// counterparts for use with and outside of Unity Purchasing. Define store-specific identifiers 
	// also on each platform's publisher dashboard (iTunes Connect, Google Play Developer Console, etc.)

	// General product identifiers for the consumable, non-consumable, and subscription products.
	// Use these handles in the code to reference which product to purchase. Also use these values 
	// when defining the Product Identifiers on the store. Except, for illustration purposes, the 
	// kProductIDSubscription - it has custom Apple and Google identifiers. We declare their store-
	// specific mapping to Unity Purchasing's AddProduct, below.


	//---СТРИНГ С ПОКУПКОЙ ПРЕДМЕТА ПО ИМЕНИ, ДОБАВИТЬ ТАКИЕ ЖЕ ИМЕНА В КОНСОЛИ В GPLAY))

	/*public static string kProductIDConsumable =    "consumable";   
	public static string kProductIDNonConsumable = "nonconsumable";
	public static string kProductIDSubscription =  "subscription"; */
	public static string BUY_9_GOLD    =  "gold9";
	public static string BUY_15_GOLD   =  "gold15";
	public static string BUY_25_GOLD   =  "gold25";
	public static string BUY_50_GOLD   =  "gold50";
	public static string BUY_100_GOLD  =  "gold100";
	public static string BUY_500_GOLD  =  "gold500";
	public static string BUY_1500_GOLD =  "gold1500";
	public static string BUY_NO_ADS    =  "noads";
	// Apple App Store-specific product identifier for the subscription product.
	private static string kProductNameAppleSubscription =  "com.unity3d.subscription.new";

	// Google Play Store-specific product identifier subscription product.
	private static string kProductNameGooglePlaySubscription =  "com.unity3d.subscription.original"; 

	void Start()
	{
		// If we haven't set up the Unity Purchasing reference
		if (m_StoreController == null)
		{
			// Begin to configure our connection to Purchasing
			InitializePurchasing();
		}
	}

	public void InitializePurchasing() 
	{
		// If we have already connected to Purchasing ...
		if (IsInitialized())
		{
			// ... we are done here.
			return;
		}

		// Create a builder, first passing in a suite of Unity provided stores.
		var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

		// Add a product to sell / restore by way of its identifier, associating the general identifier
		// with its store-specific identifiers.
		builder.AddProduct(BUY_9_GOLD, ProductType.Consumable);
		builder.AddProduct(BUY_15_GOLD, ProductType.Consumable);
		builder.AddProduct(BUY_25_GOLD, ProductType.Consumable);
		builder.AddProduct(BUY_50_GOLD, ProductType.Consumable);
		builder.AddProduct(BUY_100_GOLD, ProductType.Consumable);
		builder.AddProduct(BUY_500_GOLD, ProductType.Consumable);
		builder.AddProduct(BUY_1500_GOLD, ProductType.Consumable);
		// Continue adding the non-consumable product.
		builder.AddProduct(BUY_NO_ADS, ProductType.NonConsumable);
		// And finish adding the subscription product. Notice this uses store-specific IDs, illustrating
		// if the Product ID was configured differently between Apple and Google stores. Also note that
		// one uses the general kProductIDSubscription handle inside the game - the store-specific IDs 
		// must only be referenced here. 


		/*builder.AddProduct(kProductIDSubscription, ProductType.Subscription, new IDs(){
			{ kProductNameAppleSubscription, AppleAppStore.Name },
			{ kProductNameGooglePlaySubscription, GooglePlay.Name },
		});*/

		// Kick off the remainder of the set-up with an asynchrounous call, passing the configuration 
		// and this class' instance. Expect a response either in OnInitialized or OnInitializeFailed.
		UnityPurchasing.Initialize(this, builder);
	}


	private bool IsInitialized()
	{
		// Only say we are initialized if both the Purchasing references are set.
		return m_StoreController != null && m_StoreExtensionProvider != null;
	}


	//----СТАНДАРТНЫЕ ФУНКЦИИ ДЛЯ ПОКУПКИ(ЦЕПЛЯЮТСЯ НА КНОПКИ!
	/*public void BuyConsumable()
	{
		// Buy the consumable product using its general identifier. Expect a response either 
		// through ProcessPurchase or OnPurchaseFailed asynchronously.
		BuyProductID(kProductIDConsumable);
	}


	public void BuyNonConsumable()
	{
		// Buy the non-consumable product using its general identifier. Expect a response either 
		// through ProcessPurchase or OnPurchaseFailed asynchronously.
		BuyProductID(kProductIDNonConsumable);
	}


	public void BuySubscription()
	{
		// Buy the subscription product using its the general identifier. Expect a response either 
		// through ProcessPurchase or OnPurchaseFailed asynchronously.
		// Notice how we use the general product identifier in spite of this ID being mapped to
		// custom store-specific identifiers above.
		BuyProductID(kProductIDSubscription);
	}*/

	//----НИЖЕ МОИ ФУНКЦИИ!

	public void Buy9Gold(){
		BuyProductID (BUY_9_GOLD);
	}

	public void Buy15Gold(){
		BuyProductID (BUY_15_GOLD);
	}

	public void Buy25Gold(){
		BuyProductID (BUY_25_GOLD);
	}

	public void Buy50Gold(){
		BuyProductID (BUY_50_GOLD);
	}

	public void Buy100Gold(){
		BuyProductID (BUY_100_GOLD);
	}

	public void Buy500Gold(){
		BuyProductID (BUY_500_GOLD);
	}

	public void Buy1500Gold(){
		BuyProductID (BUY_1500_GOLD);
	}

	public void BuyNoAds(){
		BuyProductID (BUY_NO_ADS);
	}





	void BuyProductID(string productId)
	{
		// If Purchasing has been initialized ...
		if (IsInitialized())
		{
			// ... look up the Product reference with the general product identifier and the Purchasing 
			// system's products collection.
			Product product = m_StoreController.products.WithID(productId);

			// If the look up found a product for this device's store and that product is ready to be sold ... 
			if (product != null && product.availableToPurchase)
			{
				Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
				// ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
				// asynchronously.
				m_StoreController.InitiatePurchase(product);
			}
			// Otherwise ...
			else
			{
				// ... report the product look-up failure situation  
				Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
			}
		}
		// Otherwise ...
		else
		{
			// ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
			// retrying initiailization.
			Debug.Log("BuyProductID FAIL. Not initialized.");
		}
	}


	// Restore purchases previously made by this customer. Some platforms automatically restore purchases, like Google. 
	// Apple currently requires explicit purchase restoration for IAP, conditionally displaying a password prompt.
	public void RestorePurchases()
	{
		// If Purchasing has not yet been set up ...
		if (!IsInitialized())
		{
			// ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
			Debug.Log("RestorePurchases FAIL. Not initialized.");
			return;
		}

		// If we are running on an Apple device ... 
		if (Application.platform == RuntimePlatform.IPhonePlayer || 
			Application.platform == RuntimePlatform.OSXPlayer)
		{
			// ... begin restoring purchases
			Debug.Log("RestorePurchases started ...");

			// Fetch the Apple store-specific subsystem.
			var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
			// Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
			// the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
			apple.RestoreTransactions((result) => {
				// The first phase of restoration. If no more responses are received on ProcessPurchase then 
				// no purchases are available to be restored.
				Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
			});
		}
		// Otherwise ...
		else
		{
			// We are not running on an Apple device. No work is necessary to restore purchases.
			Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
		}
	}


	//  
	// --- IStoreListener
	//

	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		// Purchasing has succeeded initializing. Collect our Purchasing references.
		Debug.Log("OnInitialized: PASS");

		// Overall Purchasing system, configured with products for this application.
		m_StoreController = controller;
		// Store specific subsystem, for accessing device-specific store features.
		m_StoreExtensionProvider = extensions;
	}


	public void OnInitializeFailed(InitializationFailureReason error)
	{
		// Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
		Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
	}


	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) 
	{
		// A consumable product has been purchased by this user.
		if (String.Equals(args.purchasedProduct.definition.id, BUY_9_GOLD, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("Bought 9 Gold: '{0}'", args.purchasedProduct.definition.id));
			//PlayerProfile.Instanse.Gold += 9;
			plr.Gold += 9;
		}
		// Or ... a non-consumable product has been purchased by this user.
		else if (String.Equals(args.purchasedProduct.definition.id, BUY_15_GOLD, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("Bought 15 Gold: '{0}'", args.purchasedProduct.definition.id));
			//PlayerProfile.Instanse.Gold += 15;
			plr.Gold += 15;
		}
		else if (String.Equals(args.purchasedProduct.definition.id, BUY_25_GOLD, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("Bought 25 Gold: '{0}'", args.purchasedProduct.definition.id));
			//PlayerProfile.Instanse.Gold += 25;
			plr.Gold += 25;
		}
		else if (String.Equals(args.purchasedProduct.definition.id, BUY_50_GOLD, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("Bought 50 Gold: '{0}'", args.purchasedProduct.definition.id));
			//PlayerProfile.Instanse.Gold += 50;
			plr.Gold += 50;
		}
		else if (String.Equals(args.purchasedProduct.definition.id, BUY_100_GOLD, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("Bought 100 Gold: '{0}'", args.purchasedProduct.definition.id));
			//PlayerProfile.Instanse.Gold += 100;
			plr.Gold += 100;
		}
		else if (String.Equals(args.purchasedProduct.definition.id, BUY_500_GOLD, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("Bought 500 Gold: '{0}'", args.purchasedProduct.definition.id));
			//PlayerProfile.Instanse.Gold += 500;
			plr.Gold += 500;
		}
		else if (String.Equals(args.purchasedProduct.definition.id, BUY_1500_GOLD, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("Bought 1500 Gold: '{0}'", args.purchasedProduct.definition.id));
			//PlayerProfile.Instanse.Gold += 1500;
			plr.Gold += 1500;
		}
		else if (String.Equals(args.purchasedProduct.definition.id, BUY_15_GOLD, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("Bought No Ads: '{0}'", args.purchasedProduct.definition.id));
			Debug.Log ("Ok, will no ads ever");
		}
		else 
		{
			Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
		}

		// Return a flag indicating whether this product has completely been received, or if the application needs 
		// to be reminded of this purchase at next app launch. Use PurchaseProcessingResult.Pending when still 
		// saving purchased products to the cloud, and when that save is delayed. 
		return PurchaseProcessingResult.Complete;
	}


	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		// A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
		// this reason with the user to guide their troubleshooting actions.
		Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
	}
}
