﻿namespace Application.Vehicle.Commands.UpdateVehicle;
public sealed record UpdateVehicleCommand(Guid Id,
                                          string Model,
                                          string Colour,
                                          string Plate,
                                          string Manufacturer) : IRequest;