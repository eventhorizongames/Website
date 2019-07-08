---
layout: nav
title: Game Development Platform
---

# What is the EventHorizon Game Development Platform

This is a set of micro-services that can be used to create any type of game, with an emphasis on Multiplayer and large world areas.

# Architecture Overview

The architecture is broken up into multiple services/servers.

## Identity Service

The Identity Service is a stand-alone micro-service that controls the Authentication and Authorization of all the Platform services, be it player or service-to-service communication. The Identity Service provided Login functionality for the players and administrators allowing for authorization of roles to be managed by a central service. 

## Engine/Client Service

This is the beginning GUI that a player will interface with when starting a game. This service contains all the Game Assets, be that scripts, images, models, etc. The Engine service contains all the base logic to interface with the rest of the Platform. After logging in and starting the Game a player will interface with the Core service and on successfully lookup of their client information will be connected to their Zone server.

## Core Service

The Core service is the the central service all other services interface to. This service returns the details about a client connection, like their state in the Platform and Zone location information. Zone services will also connect and is used for keep alive and connection information about other platform services.

## Zone Service

The Zone services is a Game world location. The zone server contains unique information about what a Client will interact with in the game world. The Zone server contains Agents, Player, Scripts, Logic, GUI, etc of the game world helping to localize the state of the world in a single Server instances.

The Zone service has a plugin model that allows for loading of different reusable "Plugins", technically setup as .NET Core dlls. The server state can also be tweaked with CSX, C# Scripts, and JavaScript as well. These scripts can be used to run different logic on the server and hot reloaded while the server is running. The JavaScript can be used to enhance the Client logic and reloaded and servered up by the server.

Configuration for the different systems, services, and scripts are JSON based, allow for human readable configuration. Some of this configuration can also be edited using the Dashboard Service, more details to be provided by the Dashboard Service section.

## Player Service

The Player service hold all of the player/client information for the whole platform.

## Agent Service

The Agent services hold information about Global Agents, these agents are simliar to traveling NPC's, and are more of a template to be used for global NPC's on the platform. Currently they are just like other Agents in a Zone, but will be enhanced to be a template for global Enemies, Trader, Quest Givers, etc.

## Dashboard Service

This services allows for Administrators of the Platform to manage the Player and Zone details. The services helps to keep track of Zone details, and contains a list of all currently connected Zone available on the Core server. The Dashbaord contains a editor for a Zone server allowing for the editing of scripts and configuration files. 

## Architecture High-level Image
![Platform Architecture](/image/architecture/PlatformArchitecture.png)