<div align="center">
<img src="https://raw.githubusercontent.com/dotnet/brand/main/logo/dotnet-logo.svg" height="70"/> &nbsp;&nbsp;
</div>

# 🛒 Checkout Kata (Kata09 – Back to the Checkout)

**Tech:** .NET 9 · C# · NUnit  
Repository: https://github.com/hb-mw/kata-checkout

This project is an implementation of [**CodeKata 09 – Back to the Checkout**](http://codekata.com/kata/kata09-back-to-the-checkout/).  
It simulates a retail checkout system that can scan items and calculate the total price based on configurable pricing rules such as multi-buy discounts and special offers.

---

## 🚀 Getting Started

### ✅ Clone & Test
```bash
git clone https://github.com/hb-mw/kata-checkout
cd kata-checkout
dotnet test
```

---

## ⚙️ How It Works

Each scanned item (e.g., “A”, “B”, “C”) is processed through a **checkout service** that:
1. Counts scanned items.
2. Retrieves the matching **pricing rule** from the catalogue.
3. Calculates the total price according to that rule.

The system supports multiple pricing behaviors (e.g., “3 for 130”, “Buy One Get One Free”) without changing core logic — new rules are simply added to the catalogue.

---

## 🧠 Design Pattern — Strategy Pattern

Each **pricing rule** (e.g., `MultiBuyOfferRule`, `BuyOneGetOneFreeRule`, `UnitPriceRule`) implements a shared interface `IPricingRule`.  
This design uses the **Strategy Pattern** to encapsulate varying pricing algorithms and lets the checkout dynamically choose the correct strategy at runtime.

> ✅ **Problem solved:** eliminates long conditionals for pricing rules, improving extensibility and readability.

### UML Diagram — Strategy Pattern
```
                ┌──────────────────────┐
                │     IPricingRule     │
                │  + Calculate(qty)    │
                └─────────┬────────────┘
                          │
        ┌─────────────────┼────────────────────┐
        │                 │                    │
┌──────────────┐   ┌────────────────┐   ┌────────────────────┐
│UnitPriceRule │   │MultiBuyOfferRule│   │BuyOneGetOneFreeRule│
│+ Calculate()  │   │+ Calculate()   │   │+ Calculate()        │
└──────────────┘   └────────────────┘   └────────────────────┘

                 ▲
                 │ uses
                 │
           ┌───────────────┐
           │ CheckoutService│
           │+ Scan(item)    │
           │+ GetTotalPrice()│
           └───────────────┘
```

---

## 🔄 Sequence Flow — Scan → Catalogue → PricingRule

```
User
 │
 │  Scan("A")
 ▼
CheckoutService
 │
 ├── increments count in _itemCounts
 │
 ├── calls pricingCatalogue.GetRule("A")
 ▼
PricingCatalogue
 │
 ├── returns corresponding IPricingRule (e.g., MultiBuyOfferRule)
 ▼
IPricingRule.Calculate(quantity)
 │
 ├── computes price based on rule logic
 ▼
CheckoutService
 │
 └── sums all calculated totals → returns final price
```

---

## 💡 Principles & Practices

### **Open/Closed Principle**
The system is **open for extension but closed for modification**:
- Add a new rule by implementing `IPricingRule`.
- Register it in `DefaultPricingCatalogue`.
- No changes to core checkout logic.

### **Test-Driven Development (TDD)**
Unit tests (`CheckoutServiceTests.cs`) verify behavior:
- Empty basket → `0`
- Multi‑buy discounts work (`AAA = 130`, `BB = 50`)
- Unknown SKUs throw exceptions

This ensures correctness, confidence in refactoring, and maintainability.

---

## 🧩 Structure Overview
```
├── Kata.Checkout/
│   ├── ICheckoutService.cs
│   ├── CheckoutService.cs
│   ├── helpers/
│   │   ├── PricingCatalogue.cs
│   │   └── DefaultPricingCatalogue.cs
│   └── PricingRules/
│       ├── IPricingRule.cs
│       ├── UnitPriceRule.cs
│       ├── MultiBuyOfferRule.cs
│       └── BuyOneGetOneFreeRule.cs
└── Kata.Tests/
    └── CheckoutServiceTests.cs
```

---

**Author:** Mahmoud Wizzo  
