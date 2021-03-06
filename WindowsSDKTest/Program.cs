﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            string email = "";
            string password = "";
            string proxy_url = "";
            bool run_forever = true;
            string user_input = "";

            #endregion

            #region Welcome

            welcome();

            #endregion

            #region Set-Authentication Parameters

            set_auth_parameters(out email, out password, out proxy_url);

            #endregion

            #region Instantiate-SDK

            /*
             * The default constructor is used in the first example.  Only the email adddress and password
             * need to be supplied.
             * 
             * The second constructor enables debugging via the debug output window.
             * 
             * The third constructor enables debugging via the debug output window and
             * further routes RESTful HTTPS requests through a configured proxy.  SlidePay recommends
             * using Charles Proxy as a proxy should you need to view requests and responses.
             * 
             */

            // SlidePayWindowsSDK slidepay = new SlidePayWindowsSDK(email, password);
            // SlidePayWindowsSDK slidepay = new SlidePayWindowsSDK(email, password, true);
            // SlidePayWindowsSDK slidepay = new SlidePayWindowsSDK(email, password, true, proxy_url);

            if (string_null_or_empty(proxy_url))
            {
                slidepay = new SlidePayWindowsSDK(email, password, true);
            }
            else
            {
                slidepay = new SlidePayWindowsSDK(email, password, true, proxy_url);
            }

            #endregion

            #region Find-Endpoint

            if (slidepay.sp_find_endpoint())
            {
                Console.WriteLine("Found endpoint: " + slidepay._endpoint_url);
            }
            else
            {
                exit_application("Could not find an endpoint for email " + email);
            }

            #endregion

            #region Login

            if (slidepay.sp_login())
            {
                Console.WriteLine("Successfully authenticated using email " + email);
            }
            else
            {
                exit_application("Unable to authenticate using email " + email);
            }

            #endregion

            #region Menu

            while (run_forever)
            {
                user_input = "";
                Console.WriteLine("");
                Console.Write("SlidePay SDK (? for help) > ");
                user_input = Console.ReadLine();

                if (string_null_or_empty(user_input))
                {
                    Console.WriteLine("Invalid input.  Type '?' and press ENTER for a menu.");
                    Console.WriteLine("");
                    continue;
                }

                switch (user_input)
                {
                    #region General

                    case "?":
                        menu();
                        break;

                    case "? ach":
                        menu_ach();
                        break;

                    case "? bank_account":
                        menu_bank_account();
                        break;

                    case "? payment":
                        menu_payment();
                        break;

                    case "? stored_payment":
                        menu_stored_payment();
                        break;

                    case "? report":
                        menu_report();
                        break;

                    case "q":
                        run_forever = false;
                        break;

                    case "config":
                        display_config(slidepay);
                        break;

                    case "find_endpoint":
                        if (slidepay.sp_find_endpoint()) Console.WriteLine("Found endpoint: " + slidepay._endpoint_url);
                        else exit_application("Could not find an endpoint for email " + email);
                        break;

                    case "authenticate":
                        slidepay.sp_reset();
                        set_auth_parameters(out email, out password, out proxy_url);
                        if (slidepay.sp_login()) Console.WriteLine("Successfully authenticated using email " + email);
                        else exit_application("Unable to authenticate using email " + email);
                        break;

                    #endregion

                    #region Payment

                    case "key_payment":
                        if (key_payment()) Console.WriteLine("Payment request succeeded.");
                        else Console.WriteLine("Payment request failed.");
                        break;

                    case "stored_payment":
                        if (stored_payment()) Console.WriteLine("Payment request succeeded.");
                        else Console.WriteLine("Payment request failed.");
                        break;

                    case "track1_payment":
                        if (track1_payment()) Console.WriteLine("Payment request succeeded.");
                        else Console.WriteLine("Payment request failed.");
                        break;

                    case "track2_payment":
                        if (track2_payment()) Console.WriteLine("Payment request succeeded.");
                        else Console.WriteLine("Payment request failed.");
                        break;

                    case "refund_payment":
                        if (refund_payment()) Console.WriteLine("Refund request succeeded.");
                        else Console.WriteLine("Refund request failed.");
                        break;

                    case "get_payment":
                        if (get_payment()) Console.WriteLine("Payment retrieval request succeeded.");
                        else Console.WriteLine("Payment retrieval request failed.");
                        break;

                    case "get_all_payments":
                        if (get_all_payments()) Console.WriteLine("Payment retrieval request succeeded.");
                        else Console.WriteLine("Payment retrieval request failed.");
                        break;

                    case "search_payments":
                        if (put_payment()) Console.WriteLine("Payment search request succeeded.");
                        else Console.WriteLine("Payment search request failed.");
                        break;

                    #endregion

                    #region Stored-Payment

                    case "create_stored_payment":
                        if (create_stored_payment()) Console.WriteLine("Stored payment request succeeded.");
                        else Console.WriteLine("Stored payment request failed.");
                        break;

                    case "get_stored_payment":
                        if (get_stored_payment()) Console.WriteLine("Stored payment request succeeded.");
                        else Console.WriteLine("Stored payment request failed.");
                        break;

                    case "get_all_stored_payments":
                        if (get_all_stored_payments()) Console.WriteLine("Stored payment request succeeded.");
                        else Console.WriteLine("Stored payment request failed.");
                        break;

                    case "delete_stored_payment":
                        if (del_stored_payment()) Console.WriteLine("Stored payment request succeeded.");
                        else Console.WriteLine("Stored payment request failed.");
                        break;

                    #endregion

                    #region Bank-Account

                    case "get_bank_account":
                        if (get_bank_account()) Console.WriteLine("Bank account retrieval request succeeded.");
                        else Console.WriteLine("Bank account retrieval request failed.");
                        break;
                        
                    case "get_all_bank_accounts":
                        if (get_all_bank_accounts()) Console.WriteLine("Bank account retrieval request succeeded.");
                        else Console.WriteLine("Bank account retrieval request failed.");
                        break;
                        
                    case "del_bank_account":
                        if (del_bank_account()) Console.WriteLine("Bank account delete request succeeded.");
                        else Console.WriteLine("Bank account delete request failed.");
                        break;
                        
                    case "create_bank_account":
                        if (create_bank_account()) Console.WriteLine("Bank account creation request succeeded.");
                        else Console.WriteLine("Bank account creation request failed.");
                        break;

                    #endregion

                    #region ACH

                    case "ach_balance":
                        if (post_ach_balance()) Console.WriteLine("ACH balance retrieval request succeeded.");
                        else Console.WriteLine("ACH balance retrieval request failed.");
                        break;

                    case "ach_settlement":
                        if (post_ach_settlement()) Console.WriteLine("ACH settlement request succeeded.");
                        else Console.WriteLine("ACH settlement request failed.");
                        break;

                    case "ach_retrieval":
                        if (post_ach_retrieval()) Console.WriteLine("ACH retrieval request succeeded.");
                        else Console.WriteLine("ACH retrieval request failed.");
                        break;

                    #endregion

                    #region Report

                    case "payment_report":
                        if (post_payment_report()) Console.WriteLine("Payment report retrieval request succeeded.");
                        else Console.WriteLine("Payment report retrieval request failed.");
                        break;

                    case "account_report":
                        if (post_account_report()) Console.WriteLine("Account report retrieval request succeeded.");
                        else Console.WriteLine("Payment report retrieval request failed.");
                        break;
                        
                    #endregion

                    default:
                        Console.WriteLine("Unknown command '" + user_input + "'.  Type '?' and press ENTER for a menu.");
                        continue;
                }
            }

            #endregion

            exit_application("Exiting normally.  Goodbye.");
            return;
        }
    }
}
